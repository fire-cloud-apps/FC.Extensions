using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FC.Core.Strings.Extension
{
    /// <summary>
    /// Extension class converts String to Model
    /// </summary>
    public static class ToModelExtension
    {
        /// <summary>
        /// Converts String to Model object
        /// </summary>
        /// <typeparam name="T">Model Type</typeparam>
        /// <param name="stringToDeserialize">model as json string</param>
        /// <returns>returns model object</returns>
        public static T ToModel<T>(this string stringToDeserialize)
        {
            return JsonConvert.DeserializeObject<T>(stringToDeserialize);
        }
    }
}
