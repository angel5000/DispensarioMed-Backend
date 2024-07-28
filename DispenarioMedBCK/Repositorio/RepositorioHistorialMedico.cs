using DispenarioMedBCK.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DispenarioMedBCK.Repositorio.RepositorioAgenda;

namespace DispenarioMedBCK.Repositorio
{
    public class RepositorioHistorialMedico : IRepositorioHistorialMedico
    {
        private readonly DispensarioContext context;
        public RepositorioHistorialMedico(DispensarioContext context)
        {
            this.context = context;
        }
        /* public async Task<List<Paciente>> ObtenerTodos()
         {
             return await context.Pacientes.ToListAsync();
         }*/

        public class HistorialMedic
        {
            // Otras propiedades existentes
            public int IDHistorial { get; set; }
            public string ?NombrePaciente { get; set; }
            public string? NombreMedico { get; set; }
            public string? Diagnostico { get; set; }
            public string? Sintomas { get; set; }
            public string? Tratamiento { get; set; }
            public string ? FechaHoraVisita { get; set; }
            public string ? Receta { get; set; }
        }
        public async Task<List<HistorialMedic>> HistorialMed(int id)
        {
            var historialMedico = await context.HistorialMedicos
        .Where(historial => historial.IdPaciente == id)
        .Include(historial => historial.IdPacienteNavigation)
        .Include(historial => historial.IdMedicoNavigation)
        .Include(historial => historial.FechaVisitaNavigation)
       
        .Select(hc => new HistorialMedic
        {
            IDHistorial =hc.IdHistorial,
            NombrePaciente  = hc.IdPacienteNavigation.Nombres,
            FechaHoraVisita = hc.FechaVisitaNavigation.FechaHora.HasValue
                ? hc.FechaVisitaNavigation.FechaHora.Value.ToString("dddd dd 'de' MMMM yyyy - hh:mmtt", new CultureInfo("es-ES"))
                : "Fecha no disponible",
            NombreMedico= $"{hc.IdMedicoNavigation.Apellidos} {hc.IdMedicoNavigation.Nombres}",
            Diagnostico =hc.Diagnostico,
            Sintomas=hc.Sintomas,
            Tratamiento=hc.Tratamiento,
            Receta=hc.Receta,
            })
        .ToListAsync();

            return historialMedico;
        }

           
        
        
    

    }
}
