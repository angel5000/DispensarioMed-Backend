using DispenarioMedBCK.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DispenarioMedBCK.Repositorio
{
    public class RepositorioLogin : IRepositorioLogin
    {

        private readonly DispensarioContext context;
        public RepositorioLogin(DispensarioContext context)
        {
            this.context = context;
        }

        public bool ActualizarContrasena(int userId, string nuevaContrasena)
        {
            // Encuentra el usuario por ID
            var user = context.UsuariosPacientes.SingleOrDefault(u => u.Idusuario == userId);
            if (user == null)
            {
                return false; // Usuario no encontrado
            }

            // Genera un nuevo salt
            byte[] nuevoSalt = RandomNumberGenerator.GetBytes(32);

            // Calcula el nuevo hash de la contraseña
            using var hmac = new HMACSHA512(nuevoSalt);
            byte[] nuevoHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(nuevaContrasena));

            // Actualiza el usuario en la base de datos
            user.Salt = nuevoSalt;
            user.HashedContrasena = nuevoHash;

            context.UsuariosPacientes.Update(user);
            context.SaveChanges();

            return true; // Contraseña actualizada exitosamente
        }






        public int? Login(string usuario, string contrasena)
        {
            var user = context.UsuariosPacientes.SingleOrDefault(u => u.Usuario == usuario);

            if (user == null)
            {
                Console.WriteLine("Usuario no encontrado.");
                return null; // Usuario no encontrado
            }

            // Imprime el Salt almacenado en la base de datos
            Console.WriteLine("Salt almacenado en la base de datos: " + BitConverter.ToString(user.Salt)+ user.Salt);
           string salt = Encoding.UTF8.GetString(user.Salt) ;
           string hashed = Encoding.UTF8.GetString(user.HashedContrasena);

            //  Console.WriteLine("dt: " + BitConverter.ToString(SHA1HashValue(salt+123456)));
            // Verifica la contraseña
           

            // Verifica la contraseña
            byte[] saltBytes = user.Salt;
            byte[] passwordBytes = Encoding.UTF8.GetBytes(contrasena);
            byte[] hashBytes;

            using (var hmac = new HMACSHA512(saltBytes))
            {
                hashBytes = hmac.ComputeHash(passwordBytes);
            }

            // Convierte el hash a un formato que se pueda comparar
            string computedHash = BitConverter.ToString(hashBytes).Replace("-", "").ToUpperInvariant();
            string storedHash = BitConverter.ToString(user.HashedContrasena).Replace("-", "").ToUpperInvariant();

            if (computedHash == storedHash)
            {
                // Contraseña correcta, devuelve el ID del usuario
                return user.IdDatosUsuario;
            }

            Console.WriteLine("Login exitoso. ID del usuario: " + user.IdDatosUsuario);
            return user.IdDatosUsuario; // Login exitoso, devuelve el ID del usuario
        }
        public bool VerifyPassword(string username, string password)
        {
           

         
            // Contraseña incorrecta
            return false;
        }


    }
}