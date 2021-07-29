using System;
using System.Collections.Generic;
using System.Text;

namespace FC.Core.Extension.GenericHandlers
{
    /// <summary>
    /// Compares two models or entity and retuns true if matches
    /// </summary>
    public class PropertyDifference
    {
        /// <summary>
        /// Compares the two class property and provides the list of difference
        /// </summary>
        /// <typeparam name="T">Model or Entity Type</typeparam>
        /// <param name="self">Soruce Model?</param>
        /// <param name="to">Compare with?</param>
        /// <param name="ignore">Which property to ignore</param>
        /// <returns></returns>
        public static IList<PropertyDiff> GetDifference<T>(T self, T to, params string[] ignore) where T : class
        {
            IList<PropertyDiff> propertyDiffs = new List<PropertyDiff>();
            if (self != null && to != null)
            {
                Type type = typeof(T);
                List<string> ignoreList = new List<string>(ignore);
                foreach (System.Reflection.PropertyInfo pi in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                {
                    if (!ignoreList.Contains(pi.Name))
                    {
                        object selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                        object toValue = type.GetProperty(pi.Name).GetValue(to, null);

                        if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                        {
                            propertyDiffs.Add(new PropertyDiff()
                            {
                                SourcePropertyName = pi.Name,
                                SourceValue = selfValue,
                                DestinationPropertyName = pi.Name,
                                DestinationValue = toValue
                            });
                        }
                    }
                }
            }
            return propertyDiffs;
        }

        /// <summary>
        /// Gets the different value of two property.
        /// </summary>
        public class PropertyDiff
        {
            public string SourcePropertyName { get; set; }
            public object SourceValue { get; set; }
            public string DestinationPropertyName { get; set; }
            public object DestinationValue { get; set; }
        }
    }
}
