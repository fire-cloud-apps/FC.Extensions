using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FC.Core.Extension.StringHandlers
{
    /// <summary>
    /// Encrypt or Decrypt a string as a extension method. It uses RSA Standard algorithm to do this.
    /// </summary>
    public static class EncryptOrDecryptExtension
    {
        /// <summary>
        /// Encryptes a string using the supplied key. Encoding is done using RSA encryption.
        /// </summary>
        /// <param name="stringToEncrypt">String that must be encrypted.</param>
        /// <param name="key">Encryptionkey.</param>
        /// <returns>A string representing a byte array separated by a minus sign.</returns>
        /// <exception cref="ArgumentException">Occurs when stringToEncrypt or key is null or empty.</exception>
        public static string Encrypt(this string stringToEncrypt, string key)
        {
            if (string.IsNullOrEmpty(stringToEncrypt))
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot encrypt using an empty key. Please supply an encryption key.");
            }

            var cspp = new CspParameters
            {
                KeyContainerName = key
            };
            byte[] bytes = null;
            using (var rsa = new RSACryptoServiceProvider(cspp))
            {
                rsa.PersistKeyInCsp = true;

                bytes = rsa.Encrypt(UTF8Encoding.UTF8.GetBytes(stringToEncrypt), true);
            }

            return BitConverter.ToString(bytes);
        }

        /// <summary>
        /// Decryptes a string using the supplied key. Decoding is done using RSA encryption.
        /// </summary>
        /// <param name="stringToDecrypt">String that must be decrypted.</param>
        /// <param name="key">Decryptionkey.</param>
        /// <returns>The decrypted string or null if decryption failed.</returns>
        /// <exception cref="ArgumentException">Occurs when stringToDecrypt or key is null or empty.</exception>
        public static string Decrypt(this string stringToDecrypt, string key)
        {
            string result = null;

            if (string.IsNullOrEmpty(stringToDecrypt))
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot decrypt using an empty key. Please supply a decryption key.");
            }


            var cspp = new CspParameters
            {
                KeyContainerName = key
            };
            byte[] bytes = null;
            using (var rsa = new RSACryptoServiceProvider(cspp))
            {
                rsa.PersistKeyInCsp = true;

                var decryptArray = stringToDecrypt.Split(new string[] { "-" }, StringSplitOptions.None);
                var decryptByteArray = Array.ConvertAll<string, byte>(decryptArray, (s => Convert.ToByte(byte.Parse(s, System.Globalization.NumberStyles.HexNumber))));

                bytes = rsa.Decrypt(decryptByteArray, true);
            }

            result = UTF8Encoding.UTF8.GetString(bytes);
            return result;
        }

    }
}
