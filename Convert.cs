using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikeForensicLib
{
    static public class Convert
    {
        static public byte[] FromHexString(string input)
        {
            var result = new byte[(input.Length + 1) / 2];
            var offset = 0;
            if (input.Length % 2 == 1)
            {
                // If length of input is odd, the first character has an implicit 0 prepended.
                result[0] = (byte)System.Convert.ToUInt32(input[0] + "", 16);
                offset = 1;
            }
            for (int i = 0; i < input.Length / 2; i++)
            {
                result[i + offset] = (byte)System.Convert.ToUInt32(input.Substring(i * 2 + offset, 2), 16);
            }
            return result;
        }

        static public string ToHexString(IEnumerable<byte> input, string prefix = "", string separator = "")
        {
            var ret = "";

            return ret;
        }

        static public string ToBinaryString(IEnumerable<byte> input, string separator = "")
        {

            return string.Join(separator, input.Select(x => System.Convert.ToString(x, 2).PadLeft(8, '0')).ToArray());
        }
    }

    // We use the Extensions namespace so that these can be integrated in as needed, rather than ALWAYS being available on common objects like byte[]
    namespace Extensions
    {
        static public class ConversionHelpers
        {
            static public string ToHexString(this IEnumerable<byte> input, string prefix = "", string separator = "")
            {
                return Convert.ToHexString(input, prefix, separator);
            }

            static public byte[] FromHexString(this string input)
            {
                return Convert.FromHexString(input);
            }
        }
    }
}
