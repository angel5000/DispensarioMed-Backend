using DispenarioMedBCK.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispenarioMedBCK.Repositorio
{
    public class RepositorioPaciente:IRepositorioPaciente
    {

        private readonly DispensarioContext context;
        public RepositorioPaciente(DispensarioContext context)
        {
            this.context = context;
        }
        public async Task<List<Paciente>> ObtenerTodos()
        {
            return await context.Pacientes.ToListAsync();
        }
        public async Task<List<Paciente>> PacienteID(int id)
        {
            return await context.Pacientes.Where(paciente => paciente.IdPaciente == id).ToListAsync();

        }

    }
}
