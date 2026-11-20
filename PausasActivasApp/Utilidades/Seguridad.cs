using System;
using System.Security.Cryptography;
using System.Text;

namespace PausasActivasApp.Utilidades
{
    /// <summary>
    /// Métodos de seguridad: hashing de contraseñas con SHA-256.
    /// Las contraseñas NUNCA se almacenan en texto plano.
    /// </summary>
    public static class Seguridad
    {
        /// <summary>
        /// Calcula el hash SHA-256 de un texto en claro y lo devuelve
        /// como cadena hexadecimal en MAYÚSCULAS (64 caracteres).
        /// Coincide con: CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @texto), 2)
        /// en SQL Server.
        /// </summary>
        /// <param name="textoCrudo">Contraseña en texto plano.</param>
        /// <returns>Hash SHA-256 en hex mayúsculas, p. ej. "240BE518..."</returns>
        public static string HashSHA256(string textoCrudo)
        {
            if (string.IsNullOrEmpty(textoCrudo))
                throw new ArgumentException("El texto a hashear no puede estar vacío.", nameof(textoCrudo));

            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(textoCrudo));
                var sb = new StringBuilder(64);
                foreach (byte b in bytes)
                    sb.Append(b.ToString("X2")); // X2 = hex mayúsculas con 2 dígitos
                return sb.ToString();
            }
        }

        /// <summary>
        /// Verifica si una contraseña en texto plano coincide con un hash guardado.
        /// </summary>
        public static bool VerificarPassword(string textoCrudo, string hashGuardado)
        {
            if (string.IsNullOrEmpty(textoCrudo) || string.IsNullOrEmpty(hashGuardado))
                return false;

            string hashCalculado = HashSHA256(textoCrudo);
            // Comparación insensible a mayúsculas por seguridad adicional.
            return string.Equals(hashCalculado, hashGuardado, StringComparison.OrdinalIgnoreCase);
        }
    }
}
