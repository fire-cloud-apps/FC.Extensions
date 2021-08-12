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
        #region Get Random Number
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
        #endregion

        #region Percentage Calculation
        /// <summary>
        /// Find the percentage of a integer value
        /// </summary>
        /// <param name="value">numberical value to be calculated.</param>
        /// <param name="percent">expected percentage value</param>
        /// <returns>returns % of a value eg. 5% of 840 is 42</returns>
        public static double PercentageOf(this int value, int percent)
        {
            double perValue = (double)percent / 100;
            var actualPercentValue = (perValue * value);
            return actualPercentValue;
        }
        /// <summary>
        /// Finds the percentage of a double value
        /// </summary>
        /// <param name="value">numberical value to be calculated.</param>
        /// <param name="percent">expected percentage value</param>
        /// <returns>returns % of a value eg. 5% of 840 is 42</returns>
        public static double PercentageOf(this double value, double percent)
        {
            double perValue = (double)percent / 100;
            double actualPercentValue = (perValue * value);
            return actualPercentValue;
        }
        #endregion
    }
}
