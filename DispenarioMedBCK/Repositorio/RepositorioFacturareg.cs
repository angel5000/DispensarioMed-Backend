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
   public class RepositorioFacturareg:IRepositorioFacturareg
    {
        private readonly DispensarioMedContext context;
        public RepositorioFacturareg(DispensarioMedContext context)
        {
            this.context = context;
        }
        /* public async Task<List<Paciente>> ObtenerTodos()
         {
             return await context.Pacientes.ToListAsync();
         }*/

        public class Facturasreg
        {
            // Otras propiedades existentes
            public int IDFactura { get; set; }
            public string? NombresPaciente { get; set; }
            public string? FechaFacturacion { get; set; }
            public string? NombresMedico { get; set; }
         
        }
        public async Task<List<Facturasreg>> Facturasregs(int id)
        {
            var Facturasreg = await context.Facturas
        .Where(facturas => facturas.IdPaciente== id)
        .Include(facturas => facturas.IdPacienteNavigation)
        .Include(facturas => facturas.IdMedicoNavigation)
        .Include(facturas => facturas.FechaVisitaNavigation)

        .Select(hc => new Facturasreg
        {
            IDFactura = hc.IdFactura,
            NombresPaciente = hc.IdPacienteNavigation.Nombres,
            FechaFacturacion = hc.FechaVisitaNavigation.FechaHora.HasValue
                ? hc.FechaVisitaNavigation.FechaHora.Value.ToString("dddd dd 'de' MMMM yyyy - hh:mmtt", new CultureInfo("es-ES"))
                : "Fecha no disponible",
            NombresMedico = $"{hc.IdMedicoNavigation.Apellidos} {hc.IdMedicoNavigation.Nombres}",
           
        })
        .ToListAsync();

            return Facturasreg;
        }






    }
}
