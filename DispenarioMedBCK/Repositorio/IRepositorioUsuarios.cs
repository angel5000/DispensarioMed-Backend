using DispenarioMedBCK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DispenarioMedBCK.Repositorio.RepositorioUsuarios;

namespace DispenarioMedBCK.Repositorio
{
    public interface IRepositorioUsuarios
    {
        public Task<List<UsuariosPaciente>> ObtenerTodosUsuariosPacientesAsync();
        public  Task<List<UsuariosMedico>> ObtenerTodosMedUsuariosAsync();
        public  Task<UsuariosPaciente?> ObtenerUsuarioPacientePorIdAsync(int id);
        public  Task EliminarUsuarioPacienteAsync(int id);
        public  Task<bool> ActualizarEstadoUsuarioPacienteAsync(int id, ActualizarUsuarioPacienteDto usuarioDto);
    }
}
