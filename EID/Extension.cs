using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EID
{
    internal static class Extension
    {
        /// <summary>
        /// Determines whether the specified string begins with an uppercase character.
        /// </summary>
        /// <param name="value">The string to evaluate. Can be null or empty.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is not null or empty and its first character is
        /// uppercase; otherwise, <see langword="false"/>.</returns>
        public static bool IsCapitalized(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            return char.IsUpper(value[0]);
        }
        /// <summary>
        /// Returns a substring containing the leftmost characters of the specified string.
        /// </summary>
        /// <param name="value">The string from which to extract the leftmost characters. Cannot be <see langword="null"/>.</param>
        /// <param name="length">The number of characters to extract from the start of <paramref name="value"/>. Must be non-negative.</param>
        /// <returns>A substring containing up to <paramref name="length"/> characters from the start of <paramref
        /// name="value"/>. Returns <see cref="string.Empty"/> if <paramref name="value"/> is <see langword="null"/>,
        /// empty, or if <paramref name="length"/> is less than or equal to zero. If <paramref name="length"/> is
        /// greater than or equal to the length of <paramref name="value"/>, returns <paramref name="value"/>.</returns>
        public static string Left(this string value, int length)
        {
            if (string.IsNullOrEmpty(value) || length <= 0)
                return string.Empty;
            if (length >= value.Length)
                return value;
            return value.Substring(0, length);
        }
        /// <summary>
        /// Returns a substring containing the specified number of characters from the end of the input string.
        /// </summary>
        /// <param name="value">The string from which to extract the substring. Cannot be <see langword="null"/>.</param>
        /// <param name="length">The number of characters to retrieve from the end of <paramref name="value"/>. Must be greater than zero.</param>
        /// <returns>A substring of <paramref name="value"/> containing the last <paramref name="length"/> characters. Returns
        /// <see cref="string.Empty"/> if <paramref name="value"/> is <see langword="null"/>, empty, or if <paramref
        /// name="length"/> is less than or equal to zero. If <paramref name="length"/> is greater than or equal to the
        /// length of <paramref name="value"/>, the entire string is returned.</returns>
        public static string Right(this string value, int length)
        {
            if (string.IsNullOrEmpty(value) || length <= 0)
                return string.Empty;
            if (length >= value.Length)
                return value;
            return value.Substring(value.Length - length);
        }
    }
}
