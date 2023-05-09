using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Greendy.Common.Helpers
{
    public static class HashHelper
    {
        public static byte[] GetSalt() {
            var salt = new byte[32];
            using (var random = RandomNumberGenerator.Create())
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }
        public static string EncryptPassword(string password, byte[] salt) {
            var passwordBytes = Encoding.ASCII.GetBytes(password);

            byte[] plainTextWithSaltBytes =
                new byte[passwordBytes.Length + salt.Length];

            for (int i = 0; i < passwordBytes.Length; i++)
            {
                plainTextWithSaltBytes[i] = passwordBytes[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[passwordBytes.Length + i] = salt[i];
            }

            var hashBytes = SHA512.HashData(plainTextWithSaltBytes);
            return  Encoding.ASCII.GetString(hashBytes);
        }
    }
}