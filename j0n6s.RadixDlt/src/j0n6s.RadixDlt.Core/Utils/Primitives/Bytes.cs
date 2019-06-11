using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Utils.Primitives
{
    /// <summary>
    ///     Utility class for manipulating primitive bytes.
    /// </summary>
    public sealed class Bytes
    {
        private static char[] hexChars = {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'
        };

        private Bytes() { }

        /// <summary>
        ///     Compare two byte array segments for equality.
        /// </summary>
        /// <param name="a1">The first array to compare</param>
        /// <param name="offset1">The offset within a1 to begin the comparison</param>
        /// <param name="length1">the quantity of a1 to compary</param>
        /// <param name="a2">The second array to compare</param>
        /// <param name="offset2">The offset within a2 to begin the comparison</param>
        /// <param name="length2">The quantity of a2 to compare</param>
        /// <returns></returns>
        public static bool ArrayEquals(byte[] a1, int offset1, int length1, byte[] a2, int offset2, int length2)
        {
            if (length1 != length2)            
                return false;
            
            for (int i = 0; i < length1; ++i)
            {
                if (a1[offset1 + i] != a2[offset2 + i])                
                    return false;                
            }

            return true;
        }
        
        /// <summary>
        ///     Calculate hash code of a byte array segment.
        /// </summary>
        /// <param name="a">The array for which to calculate the hash code.</param>
        /// <param name="offset">The offset within the array to start the calculation.</param>
        /// <param name="length">The number of bytes for which to calculate the hash code.</param>
        /// <returns>The hash code</returns>
        public static int HashCode(byte[] a, int offset, int length)
        {
            int i = length;
            int hc = i + 1;
            while (--i >= 0)
            {
                hc *= 257;
                hc ^= a[offset + i];
            }
            return hc;
        }

        /// <summary>
        ///     Convert a byte array into a {@link String} using the
        ///     {@link RadixConstants#STANDARD_CHARSET} character set.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns></returns>
        public static string ToString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Convert a byte into a two-digit hex string.
        /// 
        /// Note that digits a-f are output as lower case.
        /// </summary>
        public static string ToHexString(byte b)
        {
            char[] value = {
                ToHexChar(b >> 4), ToHexChar(b)
            };
            return new string(value);
        }

        public static String ToHexString(byte[] bytes)
        {
            return ToHexString(bytes, 0, bytes.Length);
        }

        public static string ToHexString(byte[] bytes, int offset, int length)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; ++i)
            {
                sb.Append(ToHexString(bytes[offset + i]));
            }
            return sb.ToString();
        }

        public static byte[] FromHexString(string s)
        {
            int byteCount = (s.Length + 1) / 2;
            byte[] bytes = new byte[byteCount];
            int index = 0;
            int offset = 0;
            // If an odd number of chars, assume leading zero
            if ((s.Length & 1) != 0)
            {
                bytes[offset++] = FromHexNybble(s[index++]);
            }
            while (index < s.Length)
            {
                byte msn = FromHexNybble(s[index++]);
                byte lsn = FromHexNybble(s[index++]);
                bytes[offset++] = (byte)((msn << 4) | lsn);
            }
            return bytes;
        }


        /// <summary>
        ///     
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToBase64String(byte[] bytes)
        {
            // TODO : this might night to comply with https://tools.ietf.org/html/rfc4648
            return Convert.ToBase64String(bytes);                        
        }

        public static byte[] FromBase64String(string s)
        {
            return Convert.FromBase64String(s);
        }

        private static char ToHexChar(int value)
        {
            return hexChars[value & 0xF];
        }

        private static byte FromHexNybble(char value)
        {
            char c = Char.ToLower(value);
            if (c >= '0' && c <= '9')
            {
                return (byte)(c - '0');
            }
            if (c >= 'a' && c <= 'f')
            {
                return (byte)(10 + c - 'a');
            }
            throw new ArgumentException("Unknown hex digit: " + value);
        }

        public static byte[] TrimLeadingZeros(byte[] bytes)
        {
            if (bytes == null || bytes.Length <= 1 || bytes[0] != 0)
            {
                return bytes;
            }
            int trimLeadingZeros = 1;
            int maxTrim = bytes.Length - 1;
            while (trimLeadingZeros < maxTrim && bytes[trimLeadingZeros] == 0)
            {
                trimLeadingZeros += 1;
            }

            byte[] result = new byte[bytes.Length - trimLeadingZeros];
            Array.Copy(bytes, trimLeadingZeros, result, 0, bytes.Length - trimLeadingZeros);
            return result;
        }

    }
}
