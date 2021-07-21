using System;
using System.Collections.Generic;
using System.Text;

namespace FC.Extension.HTTP.HTTPHandlers
{
    /// <summary>
    /// Extension methods for Encode and Decode string based on Base64
    /// </summary>
    public static class Base64Extension
    {
        /// <summary>
        /// Base 64 Decode
        /// </summary>
        /// <param name="base64EncodedData">Base 64 Encoded Data</param>
        /// <example>
        /// <code lang="csharp">
        /// string value = ".....";
        /// value.ToBase64Decode();
        /// </code>
        /// <returns>Plain Text</returns>
        public static string ToBase64Decode(this string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Base 64 Encode
        /// </summary>
        /// <param name="plainText">Plain Text</param>
        /// <example>
        /// <code lang="csharp">
        /// string value = ".....";
        /// value.ToBase64Encode();
        /// </code>
        /// </example>
        /// <returns>Encoded Data</returns>
        public static string ToBase64Encode(this string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

    }
}
