﻿using DispenarioMedBCK.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispenarioMedBCK.Repositorio
{
   public class RepositorioAgenda: IRepositorioAgenda
    {
        private readonly DispensarioContext context;
        public RepositorioAgenda(DispensarioContext context)
        {
            this.context = context;
        }
        public class HorarioCitaDTO
        {
            public int IdHorario { get; set; }
            public string FechaHora { get; set; }
            public string NombreDoctor { get; set; }
            public string Disponibilidad { get; set; }
            public string Direccion { get; set; }
            public string Habitacion { get; set; }
            public string Especialidad { get; set; }
        }

        public async Task<List<HorarioCitaDTO>> ObtenerDisponible(string sector, string especialidad)
        {
            var result = await context.HorariosCitas
        .Include(hc => hc.IdDoctorNavigation)
        .Include(hc => hc.Disponibe)
       
.Include(hc => hc.AreasNavigation)


            .ThenInclude(a => a.UbicacionareaNavigation)
              .Where(hc => hc.Disponibeid == 1)
              .Where(hc => hc.AreasNavigation.UbicacionareaNavigation.Sector == sector)
        .Where(hc => hc.IdDoctorNavigation.Especialidad == especialidad)
        .Select(hc => new HorarioCitaDTO
        {
            IdHorario=hc.IdHorario,
            Especialidad=hc.IdDoctorNavigation.Especialidad,
            FechaHora = hc.FechaHora.HasValue
                ? hc.FechaHora.Value.ToString("dddd dd 'de' MMMM yyyy - hh:mmtt", new CultureInfo("es-ES"))
                : "Fecha no disponible",
            NombreDoctor = hc.IdDoctorNavigation.Nombres, // Asume que la entidad Medico tiene una propiedad Nombre
            Disponibilidad = hc.Disponibe.Disponibilidad, // Asume que la entidad EstadoHoraCita tiene una propiedad Nombre
            Direccion = hc.AreasNavigation.UbicacionareaNavigation.Direccion,
            Habitacion = hc.AreasNavigation.Habitacion
        })
        .ToListAsync();

            return result;
        }

     
        }
}
