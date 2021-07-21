using System;
using System.Collections.Generic;
using System.Text;

namespace FC.Core.Extension.StringHandlers
{
    public static class TruncateExtension
    {
		/// <summary>
		/// Truncates the string to a specified length and replace the truncated to a ...
		/// </summary>
		/// <param name="text">string that will be truncated</param>
		/// <param name="maxLength">total length of characters required as output</param>
		/// <example>
		/// <code lang="csharp">
		/// string myvalue = "this is the large string";
		/// myvalue.Truncate(7);//will return this...
		/// </code>
		/// </example>
		/// <returns>truncated string</returns>
		public static string Truncate(this string text, int maxLength)
		{
			// replaces the truncated string to a ...
			const string suffix = "...";
			string truncatedString = text;

			if (maxLength <= 0) return truncatedString;
			int strLength = maxLength - suffix.Length;

			if (strLength <= 0) return truncatedString;

			if (text == null || text.Length <= maxLength) return truncatedString;

			truncatedString = text.Substring(0, strLength);
			truncatedString = truncatedString.TrimEnd();
			truncatedString += suffix;
			return truncatedString;
		}
	}
}
