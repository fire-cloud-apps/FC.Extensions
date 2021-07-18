using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FC.Core.Strings.Extension
{
    /// <summary>
    /// Extension class which converts string to stream object
    /// </summary>
    public static class ToStreamExtension
    {
        /// <summary>
        /// Converts String to Stream Object
        /// </summary>
        /// <param name="this">string value</param>
        /// <example>
        /// <code>
        /// string value = "MyString";
        /// Stream stream = value.ToStream();
        /// </code>
        /// </example>
        /// <returns>returns stream object</returns>
        public static Stream ToStream(this string @this)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(@this);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
