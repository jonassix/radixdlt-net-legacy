using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Utils.Primitives
{
    /// <summary>
    ///      Some useful string handling methods, currently mostly here for performance reasons.
    /// </summary>
    public sealed class Strings
    {
        private Strings(){}

        /// <summary>
        /// Brutally convert a string to a sequence of ASCII bytes by
        /// discarding all but the lower 7 bits of each {@code char} in
        /// </summary>
        /// {@code s}.
        /// 
        /// The primary purpose of this method is to implement a speedy
        /// converter between strings and bytes where characters are
        /// known to be limited to the ASCII character set.
        /// 
        /// Note that the output will consume exactly {@code s.length()}
        /// bytes.
        /// <param name="s">The string to convert.</param>
        /// <param name="bytes">The buffer to place the converted bytes into.</param>
        /// <param name="ofs">The offset within the buffer immediately past the converted string.</param>
        /// <returns>The offset within the buffer immediately past the converted string.</returns>
        public static int ToASCIIBytes(string s, byte[] bytes, int ofs)
        {
            for (int i = 0; i < s.Length; ++i)
            {                
                bytes[ofs++] = (byte)(s[i] & 0x7F);
            }
            return ofs;
        }

        /// <summary>
        /// Convert a sequence of ASCII bytes into a string.  Note that
        /// no bounds checking is performed on the incoming bytes;
        /// the upper bit is silently discarded.        
        /// </summary>
        /// <param name="bytes">The buffer to convert to a string.</param>
        /// <param name="ofs">The offset within the buffer to start conversion.</param>
        /// <param name="len">The number of bytes to convert.</param>
        /// <returns>A {@link String} of length {@code len}.</returns>
        public static String fromAsciiBytes(byte[] bytes, int ofs, int len)
        {
            char[] chars = new char[len];
            for (int i = 0; i < len; ++i)
            {
                chars[i] = (char)(bytes[ofs + i] & 0x7F);
            }
            return new String(chars);
        }
    }


}
