using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace FC.Core.Extension.StringHandlers
{
    public static class ToPasswordHashExtension
    {
        #region Public Methods
        /// <summary>
        /// Generates the password Hash in a most recommended way using 'KeyDerivation.Pbkdf2' and 'Rfc2898DeriveBytes'
        /// </summary>
        /// <param name="password">string that has to be hased</param>
        /// <param name="saltValue">Salt value, if null it will be genereted and returns the salt</param>
        /// <example>
        /// <code lang="csharp">
        /// string myvalue = "this is the large string";
        /// PasswordHashInfo pInfo = myvalue.ToPasswordHash();
        /// var pswd = pInfo.PasswordHash;
        /// var saltArray = pInfo.SaltAsByteArray;
        /// var saltString = pInfo.SaltAsString;
        /// </code>
        /// </example>
        /// <returns>returns PasswordHashInfo</returns>
        public static PasswordHashInfo ToPasswordHash(this string password, string saltValue)
        {
            string salt = saltValue;
            if (salt == null)
            {
                salt = GetSaltAsString();
            }
            byte[] saltByte = Convert.FromBase64String(salt);
            PasswordHashInfo passwordHash = PasswordHashing(password, saltByte);
            return passwordHash;
        }
        /// <summary>
        /// Generates the password Hash in a most recommended way using 'KeyDerivation.Pbkdf2' and 'Rfc2898DeriveBytes'
        /// </summary>
        /// <param name="password">string that has to be hased</param>
        /// <param name="saltValue">Salt value, if null it will be genereted and returns the salt</param>
        /// <example>
        /// <code lang="csharp">
        /// string myvalue = "this is the large string";
        /// PasswordHashInfo pInfo = myvalue.ToPasswordHash();
        /// var pswd = pInfo.PasswordHash;
        /// var saltArray = pInfo.SaltAsByteArray;
        /// var saltString = pInfo.SaltAsString;
        /// </code>
        /// </example>
        /// <returns>returns PasswordHashInfo</returns>
        public static PasswordHashInfo ToPasswordHash(this string password, byte[] saltValue = null)
        {
            byte[] salt = saltValue;
            if (salt == null)
            {
                salt = GetSaltAsByte();
            }
            PasswordHashInfo passwordHash = PasswordHashing(password, salt);            
            return passwordHash;
        }

        #endregion

        #region Public Helper Methods
        /// <summary>
        /// Get the salt value, which is used to hash the password.
        /// </summary>
        /// <returns>Returns salt as byte array</returns>
        public static byte[] GetSaltAsByte()
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }
        /// <summary>
        /// Get the salt value, which is used to hash the password.
        /// </summary>
        /// <returns>Returns salt as String value</returns>
        public static string GetSaltAsString()
        {
            byte[] salt = GetSaltAsByte();
            string sSalt = Convert.ToBase64String(salt);
            return sSalt;
        }
        #endregion

        private static PasswordHashInfo PasswordHashing(string password, byte[] salt)
        {
            PasswordHashInfo passwordHash = new PasswordHashInfo();
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            passwordHash.PasswordHash = hashed;
            passwordHash.SaltAsByteArray = salt;
            passwordHash.SaltAsString = Convert.ToBase64String(salt);
            return passwordHash;
        }
       
    }

    //Ref:
    //https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-5.0

    public class PasswordHashInfo
    {
        public string PasswordHash { get; set; }
        public byte[] SaltAsByteArray { get; set; }
        public string SaltAsString { get; set; }
    }
}
