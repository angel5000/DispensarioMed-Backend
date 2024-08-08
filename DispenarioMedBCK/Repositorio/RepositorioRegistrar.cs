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
namespace DispenarioMedBCK.Repositorio
{
public class RepositorioRegistrar:IRepositorioRegistrar
    {
        private readonly DispensarioMedContext context;
        public RepositorioRegistrar(DispensarioMedContext context)
        {
            this.context = context;
        }
        public class PacienteCreateDto
        {
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
    public  class UsuariosPacientes
        {
            
            public int? IdDatosUsuario { get; set; }
            public string? Usuario { get; set; }
            public int? Rol { get; set; }
            public string? Activa { get; set; }
            [JsonIgnore]
            public byte[] Salt { get; set; } = null!;
            public byte[] HashedContrasena { get; set; } = null!;
            [JsonIgnore]
            public virtual Paciente? IdDatosUsuarioNavigation { get; set; }
            [JsonIgnore]
            public virtual Rol? RolNavigation { get; set; }
        }

        public async Task<bool> RegistrarPaciente(PacienteCreateDto usuarioDto)
        {
            if (usuarioDto == null)
            {
                throw new ArgumentNullException(nameof(usuarioDto));
            }

            // Mapea el DTO a la entidad Paciente
            var usuario = new Paciente
            {
                Cedula = usuarioDto.Cedula,
                Nombres = usuarioDto.Nombres,
                Apellidos = usuarioDto.Apellidos,
                FechaNacimiento = usuarioDto.FechaNacimiento,
                Provincia = usuarioDto.Provincia,
                Direccion = usuarioDto.Direccion,
                NumCelular = usuarioDto.NumCelular,
                Canton = usuarioDto.Canton,
                Genero = usuarioDto.Genero,
                CorreoElectronico = usuarioDto.CorreoElectronico
             
            };

            context.Set<Paciente>().Add(usuario);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> RegistrarUsuariocContra(UsuariosPacientes userdt)
        {


            if (userdt == null)
            {
                throw new ArgumentNullException(nameof(userdt));
            }

            // Genera un nuevo salt

            // Generar un salt aleatorio
            using (var rng = new RNGCryptoServiceProvider())
            {
                userdt.Salt = new byte[32];
                rng.GetBytes(userdt.Salt);
            }

            // Convertir salt y contraseña a cadena y concatenarlas
            string saltString = Convert.ToBase64String(userdt.Salt);
            string passwordString = Convert.ToBase64String(userdt.HashedContrasena);

            // Hashear la contraseña usando SHA-512
            using (var sha512 = SHA512.Create())
            {
                var combinedBytes = Encoding.UTF8.GetBytes(saltString + passwordString);
                userdt.HashedContrasena = sha512.ComputeHash(combinedBytes);
            }

            context.Set<UsuariosPacientes>().Add(userdt);

            var result = await context.SaveChangesAsync();
            return result > 0;


        }
        }
    
    
}
