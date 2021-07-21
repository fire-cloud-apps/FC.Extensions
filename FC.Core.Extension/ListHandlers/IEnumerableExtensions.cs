using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FC.Core.Extension.ListHandlers
{
    /// <summary>
    /// Extension method for IEnumerable
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Extension method to execute ForEach action
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="array">Array of object</param>
        /// <param name="action">An action method to execute</param>
        /// <example>
        /// <code lang="csharp">
        /// string[] names = new string[] { "C#", "Java" };
        /// names.ForEach(i => Console.WriteLine(i));
        /// //or
        /// IEnumerable<int> namesLen = names.ForEach(i => i.Length);
        /// namesLen.ForEach(i => Console.WriteLine(i));
        /// </code>
        /// </example>
        /// <returns>returns the response as array</returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> array, Action<T> action)
        {
            foreach (var i in array)
            {
                action(i);
            }
            return array;
        }

        /// <summary>
        /// Extension method execute ForEach action
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="array">Array of object</param>
        /// <param name="action">An action method to execute</param>
        /// <example>
        /// <code lang="csharp">
        /// string[] names = new string[] { "C#", "Java" };
        /// names.ForEach(i => Console.WriteLine(i));
        /// //or
        /// IEnumerable<int> namesLen = names.ForEach(i => i.Length);
        /// namesLen.ForEach(i => Console.WriteLine(i));
        /// </code>
        /// </example>
        /// <returns>returns the response as array</returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable array, Action<T> action)
        {
            return array.Cast<T>().ForEach<T>(action);
        }

        /// <summary>
        /// Extension method execute ForEach action
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <typeparam name="RT">Destination Type</typeparam>
        /// <param name="array">Array of object</param>
        /// <param name="func">an function to execute</param>
        /// <example>
        /// <code lang="csharp">
        /// string[] names = new string[] { "C#", "Java" };
        /// names.ForEach(i => Console.WriteLine(i));
        /// //or
        /// IEnumerable<int> namesLen = names.ForEach(i => i.Length);
        /// namesLen.ForEach(i => Console.WriteLine(i));
        /// </code>
        /// </example>
        /// <returns>returns the response as array</returns>
        public static IEnumerable<RT> ForEach<T, RT>(this IEnumerable<T> array, Func<T, RT> func)
        {
            var list = new List<RT>();
            foreach (var i in array)
            {
                var obj = func(i);
                if (obj != null)
                    list.Add(obj);
            }
            return list;
        }
    }
}
/*
 * 
    

    IEnumerable<int> namesLen = names.ForEach(i => i.Length);
    namesLen.ForEach(i => Console.WriteLine(i));
 */