using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace MusicController.Common.HelperClasses
{
    public static class PasswordHelper
    {
        public static string EncryptPassword(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return passwordHash;
        }
        public static bool VerifyPassword(string password ,string hashPassword)
        {
          return  BCrypt.Net.BCrypt.Verify(password ,hashPassword);
        }
        //public static Tuple<string, byte[]> EncryptPassword(this string password)
        //{
        //    byte[] salt = new byte[128 / 8];
        //    using (var rng = RandomNumberGenerator.Create())
        //    {
        //        rng.GetBytes(salt);
        //    }
        //    // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
        //    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        //        password: password,
        //        salt: salt,
        //        prf: KeyDerivationPrf.HMACSHA1,
        //        iterationCount: 10000,
        //        numBytesRequested: 256 / 8
        //        ));
        //    return Tuple.Create(hashed, salt);
        //}
        //public static bool VerifyPassword(this byte[] salt,  string LoginPassword , string OutletPassword)
        //{
        //    string encryptedPassw = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        //        password: LoginPassword,
        //        salt:  salt,
        //        prf: KeyDerivationPrf.HMACSHA1,
        //        iterationCount: 10000,
        //        numBytesRequested: 256 / 8
        //    ));
        //    return encryptedPassw == OutletPassword;
        //}
    }
}
