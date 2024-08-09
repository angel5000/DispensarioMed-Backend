using DispenarioMedBCK.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using static DispenarioMedBCK.Repositorio.RepositorioRegistrar;
using System.ComponentModel.DataAnnotations.Schema;
namespace DispenarioMedBCK.Repositorio
{
    public class RepositorioRegistrar : IRepositorioRegistrar
    {
        private readonly DispensarioMedContext context;
        public RepositorioRegistrar(DispensarioMedContext context)
        {
            this.context = context;
        }
        public class PacientCreateDto
        {
            public int idPaciente { get; set; }
            public string Cedula { get; set; } = null!;

            public string? Nombres { get; set; }

            public string? Apellidos { get; set; }

            public string? FechaNacimiento { get; set; }

            public string? Provincia { get; set; }

            public string? Direccion { get; set; }

            public string? NumCelular { get; set; }

            public string? Canton { get; set; }

            public string? Genero { get; set; }

            public string? CorreoElectronico { get; set; }


        }
        private Paciente MapDtoToPaciente(PacientCreateDto dto)
        {
            return new Paciente
            {
                Cedula = dto.Cedula,
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                FechaNacimiento = dto.FechaNacimiento,
                Provincia = dto.Provincia,
                Direccion = dto.Direccion,
                NumCelular = dto.NumCelular,
                Canton = dto.Canton,
                Genero = dto.Genero,
                CorreoElectronico = dto.CorreoElectronico
            };
        }


        public class UsuariosPacientes
        {
            public int? IdDatosUsuario { get; set; }
            public string? Usuario { get; set; }
            public int? Rol { get; set; }
            public string? Activa { get; set; }


            public byte[] Salt { get; set; } = null!;

            public byte[] HashedContrasena { get; set; } = null!;

            [NotMapped]
            public string? Password { get; set; }

            [JsonIgnore]
            public virtual Paciente? IdDatosUsuarioNavigation { get; set; }

            [JsonIgnore]
            public virtual Rol? RolNavigation { get; set; }
        }

        public async Task<bool> RegistrarPaciente(Paciente usuarioDto)
        {
            if (usuarioDto == null)
            {
                throw new ArgumentNullException(nameof(usuarioDto));
            }

            try
            {
             //   var paciente = MapDtoToPaciente(usuarioDto);
                context.Pacientes.Add(usuarioDto);
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
        public class UsuarioPacienteDto
        {
            public int? IdDatosUsuario { get; set; }
            public string? Usuario { get; set; }
            public int? Rol { get; set; }
            public string? Activa { get; set; }
            public string? Password { get; set; } // Contraseña en texto plano
        }

        public async Task<bool> RegistrarUsuariocContra(UsuarioPacienteDto userDto)
        {

            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            var user = new UsuariosPaciente
            {
                IdDatosUsuario= userDto.IdDatosUsuario,
                Usuario = userDto.Usuario,
                Rol = userDto.Rol,
                Activa = userDto.Activa
            };

            // Generar un nuevo salt
            using (var rng = new RNGCryptoServiceProvider())
            {
                user.Salt = new byte[32];
                rng.GetBytes(user.Salt);
            }

            // Hashear la contraseña usando SHA-512 junto con el salt
            using (var sha512 = SHA512.Create())
            {
                var combinedBytes = Encoding.UTF8.GetBytes(Convert.ToBase64String(user.Salt) + userDto.Password);
                user.HashedContrasena = sha512.ComputeHash(combinedBytes);
            }

            context.UsuariosPacientes.Add(user);

            var result = await context.SaveChangesAsync();
            return result > 0;

        }
    } 
    
    
}
