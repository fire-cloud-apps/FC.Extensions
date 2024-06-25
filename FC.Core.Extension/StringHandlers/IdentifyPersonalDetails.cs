using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FC.Core.Extension.StringHandlers;
public static class IdentifyPersonalDetails
{
    /// <summary>
    /// SSN (Social Security Number) Format, you can change by re-assigning. Eg.  (XXX-XX-XXXX).
    /// </summary>
    public static string SocialSecurityNumber { get; set; } = @"\b\d{3}-\d{2}-\d{4}\b";
    /// <summary>
    /// Email address Format
    /// </summary>
    public static string Email { get; set; } = @"\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}\b";
    /// <summary>
    /// Phone number (US format) Eg. (XXX-XXX-XXXX or (XXX) XXX-XXXX)
    /// </summary>
    public static string PhoneNumberUS { get; set; } = @"\(?\d{3}\)?[-.\s]\d{3}[-.\s]\d{4}";
    /// <summary>
    /// Indian phone number (with or without hyphens) Eg.(XXX-XXX-XXXX)
    /// </summary>
    public static string PhoneNumberIN { get; set; } = @"(?:\d{3}-\d{3}-\d{4})|\d{10}";
    /// <summary>
    /// Credit card number (basic pattern)
    /// </summary>
    public static string CreditCard { get; set; } = @"\b\d{16}\b";

    /// <summary>
    /// Full name (heuristic)
    /// </summary>
    public static string FullName { get; set; } = @"\b[A-Z][a-z]{1,}\s[A-Z]\.?\s[A-Z][a-z]{1,}\b";


    /// <summary>
    /// Identifies the necessary personal information and removes the same.
    /// </summary>
    /// <param name="text"></param>
    /// <returns>Text, with non-sensitive string.</returns>
    /// <remarks>SSN, Credit Card, PhoneNumber, Email, FullName were removed. </remarks>
    public static string IdentifyAndRemove(this string text)
    {
        List<string> matches = new List<string>();
        string[] patterns = {
            SocialSecurityNumber,  
            PhoneNumberUS,  
            PhoneNumberIN,
            Email,  
            CreditCard,  
            FullName,  
          };

        foreach (string pattern in patterns)
        {
            MatchCollection results = Regex.Matches(text, pattern);
            foreach (Match match in results)
            {
                matches.Add(match.Value);
                text.Replace(match.Value, "***.***");
            }
        }
        return text;
        //return matches.Distinct().ToList();  // Remove duplicates
    }
}

