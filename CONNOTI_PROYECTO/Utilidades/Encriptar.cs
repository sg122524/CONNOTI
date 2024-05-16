using System;
using System.Linq;
using System.Text;
using Konscious.Security.Cryptography;

namespace CONNOTI_PROYECTO.Utilidades
{
    public class Encriptar
    {
        public static string HashPassword(string password)
        {
            // Genera un salt aleatorio
            byte[] salt = GenerateSalt();

            // Configuración de Argon2
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8, // Número de núcleos a utilizar
                MemorySize = 1024 * 64,  // Memoria en KB
                Iterations = 4           // Número de iteraciones
            };

            byte[] hash = argon2.GetBytes(16); // Tamaño del hash

            // Combina el salt y el hash en un solo string
            byte[] hashBytes = new byte[salt.Length + hash.Length];
            Buffer.BlockCopy(salt, 0, hashBytes, 0, salt.Length);
            Buffer.BlockCopy(hash, 0, hashBytes, salt.Length, hash.Length);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            // Extrae el salt del hash
            byte[] salt = new byte[16];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, salt.Length);

            // Configuración de Argon2
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                MemorySize = 1024 * 64,
                Iterations = 4
            };

            byte[] hash = argon2.GetBytes(16);

            // Compara el hash generado con el hash almacenado
            for (int i = 0; i < hash.Length; i++)
            {
                if (hashBytes[i + salt.Length] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static byte[] GenerateSalt()
        {
            var salt = new byte[16]; // Tamaño del salt
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}
