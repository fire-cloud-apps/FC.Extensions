using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace FC.Core.Strings.Extension
{
    /// <summary>
    /// Extension class which converts XML Document to Model object
    /// </summary>
    public static class XMLToModelExtension
    {
        /// <summary>
        /// Converts XML Document to Model object
        /// </summary>
        /// <typeparam name="T">Model type</typeparam>
        /// <param name="this">xml document as string</param>
        /// <example>
        /// <code>
        ///  string xml = File.ReadAllText(@"D:\file.xml");
        ///  var catalog1 = xml.XMLToModel &lt;Model&gt; ();
        /// </code>
        /// </example>
        /// <returns>returns destination object type</returns>
        public static T XMLToModel<T>(this string @this) where T : class
        {
            var reader = XmlReader.Create(@this.Trim().ToStream(), new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document });
            return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
        }
    }

}
