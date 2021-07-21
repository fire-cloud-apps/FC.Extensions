using System;

namespace FC.Core.Extension.DateHandlers
{
    /// <summary>
    /// Extension method to get age of a given person or product etc.
    /// </summary>
    public static class AgeExtension
    {
        /// <summary>
        /// Get the current age of a person or product
        /// </summary>
        /// <param name="dateOfBirth">date of birth of a person or product</param>
        /// <example>
        /// <code lang="csharp">
        /// var dt = new DateTime(year: 1984, month: 6, day: 14);
        /// int myAge = dt.Age();
        /// </code>
        /// </example>
        /// <returns>returns data in years</returns>
        public static int Age(this DateTime dateOfBirth)
        {
            if (DateTime.Today.Month < dateOfBirth.Month ||
            DateTime.Today.Month == dateOfBirth.Month &&
             DateTime.Today.Day < dateOfBirth.Day)
            {
                return DateTime.Today.Year - dateOfBirth.Year - 1;
            }
            else
                return DateTime.Today.Year - dateOfBirth.Year;
        }

        /// <summary>
        /// Get the current age of a person or product
        /// </summary>
        /// <param name="dateOfBirth">date of birth of a person or product</param>
        /// <example>
        /// <code lang="csharp">
        /// var dt = new DateTime(year: 1984, month: 6, day: 14);
        /// double myAge = dt.AgeInMonth();
        /// </code>
        /// </example>
        /// <returns>returns data in month which is the rounded value.</returns>
        public static double AgeInMonth(this DateTime dateOfBirth)
        {
            var month = DateTime.Now.Subtract(dateOfBirth).Days / (365.25 / 12);
            month = Math.Round(month);
            return month;
        }
    }
}
