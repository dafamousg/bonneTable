using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace bonneTable.Admin.Service
{
    public static class HashingFunction
    {
        public static string HashPassword(string password, string salt)
        {
            byte[] convertedSalt = Convert.FromBase64String(salt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: convertedSalt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            Console.WriteLine($"Hashed: {hashed}");

            return hashed;
        }
    }
}
