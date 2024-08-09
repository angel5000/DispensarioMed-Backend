using DispenarioMedBCK.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DispenarioMedBCK.Repositorio.RepositorioCitasMedicas;
using static DispenarioMedBCK.Repositorio.RepositorioRegistrar;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DispenarioMedBCK.Repositorio
{
    public class RepositorioCitasMedicas:IRepositorioCitasMedicas
    {

        private readonly DispensarioMedContext context;
        public RepositorioCitasMedicas(DispensarioMedContext context)
        {
            this.context = context;
        }


        public class CitasMedicas
        {
            public int idHorariosCitas{ get; set; }
            public int IDPaciente { get; set; }
            public string FechaHora { get; set; }
            public string FechaFin { get; set; }
            public string NombreDoctor { get; set; }
            public string Disponibilidad { get; set; }
            public string Direccion { get; set; }
            public string Habitacion { get; set; }
            public string Especialidad { get; set; }
            public string Sector { get; set; }
            public virtual HorariosCitas IDHorarioCitasNavigation { get; set; }
        }
        public class CitaMedicadto
        {
         
            public int IdPaciente { get; set; }
            public int IdMedico { get; set; }
            public int IdHorarioCitas { get; set; }
            public int? Motivo { get; set; }
        }

        private CitasMedica MapDtoToPaciente(CitaMedicadto dto)
        {
            return new CitasMedica
            {
                Idpaciente = dto.IdPaciente,
                Idmedico = dto.IdMedico,
                IdhorarioCitas = dto.IdHorarioCitas,
                Motivo = dto.Motivo
              
       

    };
        }




        public async Task<bool> IngresarCitaMedicaAsync(CitasMedica dto)
        {
            if (dto== null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            try
            {
                var horarioCitas = await context.HorariosCitas.FindAsync(dto.IdhorarioCitas);
                if (horarioCitas == null)
                {
                    throw new InvalidOperationException("Horario de citas no encontrado.");
                }

                // 2. Establecer el estado a 2 en la entidad HorariosCita
                horarioCitas.Disponibeid = 2;
                context.CitasMedicas.Add(dto);
                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones y logging
                // Ejemplo: Logger.LogError(ex, "Error al registrar paciente.");
                throw; // O manejar la excepción de una manera adecuada
            }
        }
        private async Task<bool> SaveChangesAsync()
        {
            var result = await context.SaveChangesAsync();
            return result > 0;
        }










        public class HorariosCitas
        {
            public int IDHorario { get; set; }
            public string FechaHora { get; set; }
            public int Disponibilidad { get; set; }
        }








        public async Task<List<CitasMedicas>> ObtenerCitasMedicas(int id)
        {

            var result = await context.CitasMedicas
                .Where(historial => historial.Idpaciente == id)
        .Include(hc => hc.IdmedicoNavigation)
       .Include(hc => hc.IdhorarioCitasNavigation)

        .Select(hc => new CitasMedicas
        {
            IDPaciente=hc.Idpaciente,
            idHorariosCitas=hc.IdhorarioCitas,
            Especialidad = hc.IdmedicoNavigation.Especialidad,
            FechaHora = hc.IdhorarioCitasNavigation.FechaHora.HasValue
                ? hc.IdhorarioCitasNavigation.FechaHora.Value.ToString("dddd dd 'de' MMMM yyyy - hh:mmtt", new CultureInfo("es-ES"))
                : "Fecha no disponible",
            FechaFin = hc.IdhorarioCitasNavigation.FechaFin.HasValue
                ? hc.IdhorarioCitasNavigation.FechaFin.Value.ToString("dddd dd 'de' MMMM yyyy - hh:mmtt", new CultureInfo("es-ES"))
                : "Fecha no disponible",
            NombreDoctor = hc.IdmedicoNavigation.Nombres, // Asume que la entidad Medico tiene una propiedad Nombre
            Disponibilidad = hc.IdhorarioCitasNavigation.Disponibe.Disponibilidad, // Asume que la entidad EstadoHoraCita tiene una propiedad Nombre
            Direccion = hc.IdmedicoNavigation.UbicacionDispNavigation.Direccion,
            Habitacion = hc.IdhorarioCitasNavigation.AreasNavigation.Habitacion,
            Sector=hc.IdmedicoNavigation.UbicacionDispNavigation.Sector,
        })
        .ToListAsync();

            return result;
        }
        public async Task<bool> ReprogramarCitaAsync(int idPaciente, int idHorario, int idHorarioAnterior)
        {
            var cita = await context.CitasMedicas
                .Include(c => c.IdhorarioCitasNavigation) // Incluye la navegación del horario
                .FirstOrDefaultAsync(c => c.Idpaciente == idPaciente);

            if (cita == null)
            {
                return false; // No se encontró la cita
            }

            // Actualizar el horario de la cita
            cita.IdhorarioCitas = idHorario;

            // Marcar el horario anterior como disponible
            if (cita.IdhorarioCitasNavigation != null)
            {
                var horarioAnterior = await context.HorariosCitas
                    .FirstOrDefaultAsync(h => h.IdHorario == idHorarioAnterior);

                if (horarioAnterior != null)
                {
                    horarioAnterior.Disponibeid = 1; // 1 = disponible
                }
            }

            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> CancelarCitaMedica(int idPaciente, int idHorario)
        {
            var cita = await context.CitasMedicas
                .Include(c => c.IdhorarioCitasNavigation) // Incluye la navegación del horario
                .FirstOrDefaultAsync(c => c.Idpaciente == idPaciente);

            if (cita == null)
            {
                return false; // No se encontró la cita
            }

            // Actualizar el horario de la cita
            cita.IdhorarioCitas = idHorario;

            // Marcar el horario anterior como disponible
            if (cita.IdhorarioCitasNavigation != null)
            {
                var horario = await context.HorariosCitas
                    .FirstOrDefaultAsync(h => h.IdHorario == idHorario);

                if (horario != null)
                {
                    horario.Disponibeid = 4; // 1 = disponible
                }
            }

            await context.SaveChangesAsync();
            return true;
        }
    }
}
