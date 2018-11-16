using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikeForensicLib
{
    static public class Helpers
    {
        static public void Test()
        {
            
        }

        /// <summary>
        /// This function provides a shorthand way of 'snipping' a string using a start and end marker. Doing this using substring and indexOf manually
        /// requires keeping track of the startIndex as it needs to be subtracted from the endIndex to get the length.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="startMarker"></param>
        /// <param name="endMarker"></param>
        /// <returns></returns>
        static public string Snip(this string input, string startMarker, string endMarker)
        {
            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(startMarker) || string.IsNullOrWhiteSpace(endMarker) ||
                !input.Contains(startMarker) || !input.Contains(endMarker))
                return input;

            var s1 = input.IndexOf(startMarker);
            var data = input.Substring(s1, input.IndexOf(endMarker, s1) - s1);
            return data;
        }
    }

    
}
