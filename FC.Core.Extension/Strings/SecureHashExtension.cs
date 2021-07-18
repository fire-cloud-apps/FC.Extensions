
using FC.Core.Common.Extension;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FC.Core.Strings.Extension
{
    /// <summary>
    /// Secure Hash - A Class extension to hash the string with various algorithms
    /// Ref: https://emn178.github.io/online-tools/sha256.html
    /// </summary>
    public static class SecureHashExtension
    {
        /// <summary>
        /// Creates the Hash value for the String
        /// </summary>
        /// <param name="stringToHash">value of string to be hased</param>
        /// <param name="hashAlgorithms">An Algorithm which is used to Hash</param>
        /// <returns></returns>
        public static string SecureHash(this string stringToHash, HashAlgorithms hashAlgorithms = HashAlgorithms.SHA256)
        {
            string sHashValue = string.Empty;
            switch (hashAlgorithms)
            {
                case HashAlgorithms.SHA256:
                   sHashValue = SHA256_Hash(stringToHash);
                    break;
                case HashAlgorithms.SHA512:
                    sHashValue = SHA_Hash(stringToHash, new SHA512Managed());
                    break;
                case HashAlgorithms.SHA384:
                    sHashValue = SHA_Hash(stringToHash, new SHA384Managed());
                    break;                    
                default:
                    sHashValue = SHA256_Hash(stringToHash);
                    break;
            }
            return sHashValue;
        }

        #region SHA256 Hash Code

        /// <summary>
        /// Uses SHA 256 for hasing
        /// </summary>
        /// <param name="stringToHash">string to hash</param>
        /// <returns>Returns hash value </returns>
        private static string SHA256_Hash(string stringToHash)
        {
            StringBuilder Sb = new StringBuilder();
            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(stringToHash));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }

        #endregion

        #region Generic Hash
        /// <summary>
        /// Uses SHA for hasing
        /// </summary>
        /// <param name="stringToHash">string to hash</param>
        /// <param name="hashObject">Algorithm at runtime to hash</param>
        /// <returns>Returns hash value </returns>
        private static string SHA_Hash(string stringToHash, HashAlgorithm hashObject )
        {
            StringBuilder sb = new StringBuilder();
            var data = Encoding.UTF8.GetBytes(stringToHash);
            byte[] resultHash;
            using (HashAlgorithm shaM = hashObject)
            {
                resultHash = shaM.ComputeHash(data);
                foreach (Byte b in resultHash)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
        #endregion

        #region SHA512 Hash Code

        /// <summary>
        /// Uses SHA 512 for hasing
        /// </summary>
        /// <param name="stringToHash">string to hash</param>
        /// <returns>Returns hash value </returns>
        private static string SHA512_Hash(string stringToHash)
        {
            StringBuilder sb = new StringBuilder();
            var data = Encoding.UTF8.GetBytes(stringToHash);
            byte[] resultHash;
            using (SHA512 shaM = new SHA512Managed())
            {
                resultHash = shaM.ComputeHash(data);
                foreach (Byte b in resultHash)
                    sb.Append(b.ToString("x2"));
            }
           
            return sb.ToString();
        }

        #endregion

        //HashAlgorithm

    }
}
