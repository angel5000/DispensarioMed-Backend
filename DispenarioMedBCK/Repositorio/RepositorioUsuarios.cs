using DispenarioMedBCK.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispenarioMedBCK.Repositorio
{
    public class RepositorioUsuarios:IRepositorioUsuarios
    {
        private readonly DispensarioMedContext context;
        public RepositorioUsuarios(DispensarioMedContext context)
        {
            this.context = context;
        }
        public async Task<List<UsuariosPaciente>> ObtenerTodosUsuariosPacientesAsync()
        {
            return await context.UsuariosPacientes.Include(u => u.RolNavigation).Include(u => u.IdDatosUsuarioNavigation).ToListAsync();


        }
        public class ActualizarUsuarioPacienteDto
        {
            public string Estado { get; set; }
            public string Usuario { get; set; }
        }
        public async Task<bool> ActualizarEstadoUsuarioPacienteAsync(int id, ActualizarUsuarioPacienteDto usuarioDto)
        {
            var usuario = await context.UsuariosPacientes.FindAsync(id);

            if (usuario == null)
            {
                return false; // Usuario no encontrado
            }

            // Actualiza las propiedades del usuario con los datos del DTO
            usuario.Usuario = usuarioDto.Usuario;
            usuario.Activa = usuarioDto.Estado;
            // Actualiza otras propiedades según sea necesario

            context.UsuariosPacientes.Update(usuario);
            await context.SaveChangesAsync();

            return true;
        }
        public async Task<UsuariosPaciente?> ObtenerUsuarioPacientePorIdAsync(int id)
        {
            return await context.UsuariosPacientes.Include(u => u.RolNavigation).Include(u => u.IdDatosUsuarioNavigation).FirstOrDefaultAsync(u => u.Idusuario == id);
        }
        public async Task EliminarUsuarioPacienteAsync(int id)
        {
            // Obtén el usuario por ID
            var usuario = await ObtenerUsuarioPacientePorIdAsync(id);

            // Verifica si el usuario existe
            if (usuario != null)
            {
                // Cambia el estado del usuario a 'E' (Eliminado)
                usuario.Activa = "E";

                // Marca la entidad como modificada
                context.UsuariosPacientes.Update(usuario);

                // Guarda los cambios en la base de datos
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        public async Task<List<UsuariosMedico>> ObtenerTodosMedUsuariosAsync()
        {
            return await context.UsuariosMedicos.Include(m => m.RolNavigation).Include(m => m.IdDatosUsuarioNavigation).ToListAsync();
        }

       


    }
}
