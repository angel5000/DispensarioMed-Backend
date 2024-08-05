using DispenarioMedBCK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispenarioMedBCK.Repositorio
{
   public interface IRepositorioPaciente
    {
        Task<List<Paciente>> ObtenerTodos();
        Task<List<Paciente>> PacienteID(int id);
        Task<Paciente> ModificarPaciente(int id, Paciente pacienteActualizado);

    }
}
