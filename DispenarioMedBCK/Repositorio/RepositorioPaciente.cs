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
         
        private readonly DispensarioMedContext context;
        public RepositorioPaciente(DispensarioMedContext context)
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
        public async Task<Paciente> ModificarPaciente(int id, Paciente pacienteActualizado)
        {

            var pacienteExistente = await context.Pacientes.FindAsync(id);
            if (pacienteExistente == null)
            {
                throw new Exception("Paciente no encontrado");
            }

            pacienteExistente.Cedula = pacienteActualizado.Cedula;
            pacienteExistente.Nombres = pacienteActualizado.Nombres;
            pacienteExistente.Apellidos = pacienteActualizado.Apellidos;
            pacienteExistente.FechaNacimiento = pacienteActualizado.FechaNacimiento;
            pacienteExistente.Provincia = pacienteActualizado.Provincia;
            pacienteExistente.Direccion = pacienteActualizado.Direccion;
            pacienteExistente.NumCelular = pacienteActualizado.NumCelular;
            pacienteExistente.Canton = pacienteActualizado.Canton;
            pacienteExistente.Genero = pacienteActualizado.Genero;
            pacienteExistente.CorreoElectronico = pacienteActualizado.CorreoElectronico;
          

            context.Pacientes.Update(pacienteExistente);
            await context.SaveChangesAsync();

            return pacienteExistente;

        }

    }
}
