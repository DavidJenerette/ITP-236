using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EID_Assignment
{
    public static class Extensions
    {// Extension method to convert a string to proper case (first letter of each word capitalized)
        public static string ProperName(this string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;

            string[] parts = name.ToLower().Split(' ');

            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = char.ToUpper(parts[i][0]) + parts[i].Substring(1);
            }

            return string.Join(" ", parts);
        }
        /// Checks if a number is odd by using the modulus operator to determine if there is a remainder when divided by 2. 
        /// If there is a remainder, the number is odd, and the method returns true; otherwise, it returns false.
        public static bool IsOdd(this int number)
        {
            return number % 2 != 0;
        }
    }
}
