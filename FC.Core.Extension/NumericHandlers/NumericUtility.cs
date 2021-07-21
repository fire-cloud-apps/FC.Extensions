using System;
using System.Collections.Generic;
using System.Text;

namespace FC.Core.Extension.NumericHandlers
{
    /// <summary>
    /// Generats the random number
    /// </summary>
    public static class NumericUtility
    {
        private static readonly Random getrandom = new Random();
        /// <summary>
        /// Generate the random number
        /// </summary>
        /// <param name="min">min value from where the random number should be picked</param>
        /// <param name="max">maximum value from where the random number should stop</param>
        /// <returns>returns a random number</returns>
        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }
    }
}
