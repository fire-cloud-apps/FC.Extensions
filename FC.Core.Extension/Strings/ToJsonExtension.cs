using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FC.Core.Strings.Extension
{
    /// <summary>
    /// Converts String into JSON Value
    /// </summary>
   public static class ToJsonExtension
    {
        /// <summary>
        /// Converts the object as a json string
        /// Can be used for logging object contents.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="obj">The object to dump. Can be null</param>
        /// <param name="indent">To indent the result or not</param>
        /// <example>
		/// <code lang="csharp">
		/// string myvalue = "this is the large string";
		/// myvalue.Truncate(7);//will return this...
		/// </code>
		/// </example>
        /// <returns>the a string representing the object content</returns>
        public static string ToJSON<T>(this T obj, bool indent = false)
        {
            return JsonConvert.SerializeObject(obj, indent ? Formatting.Indented : Formatting.None,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        
    }
}
