using DispenarioMedBCK.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispenarioMedBCK.Repositorio
{
    public class RepositorioCitasMedicas:IRepositorioCitasMedicas
    {

        private readonly DispensarioContext context;
        public RepositorioCitasMedicas(DispensarioContext context)
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
