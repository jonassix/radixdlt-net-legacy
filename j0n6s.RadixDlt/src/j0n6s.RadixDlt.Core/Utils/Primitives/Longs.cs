using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Utils.Primitives
{
    /// <summary>
    ///     Utilities for manipulating primitive {@code long} values.
    /// </summary>
    public sealed class Longs
    {
        private Longs() { }

        /// <summary>
        ///     Create a byte array of length {@link Long#BYTES}, and
        ///     populate it with {@code value} in big-endian order.
        /// </summary>
        /// <param name="value">value The value to convert</param>
        /// <returns>The resultant byte array.</returns>
        public static byte[] ToByteArray(long value)
        {
            return CopyTo(value, new byte[sizeof(long)], 0);
        }

        /// <summary>
        ///     Copy the byte value of {@code value} into {@code bytes}
        ///     starting at {@code offset}.  A total of {@link Long#BYTES}
        ///     will be written to {@code bytes}.
        /// </summary>
        /// <param name="value">The value to convert</param>
        /// <param name="bytes">The array to write the value into</param>
        /// <param name="offset">The offset at which to write the value</param>
        /// <returns>The value of {@code bytes}</returns>
        public static byte[] CopyTo(long value, byte[] bytes, int offset)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
                        
            for (int i = offset + sizeof(long) - 1; i >= offset; i--)
            {
                bytes[i] = (byte)(value & 0xFFL);                
                value = (int)((uint)value >> 8);
            }
            return bytes;
        }

        /// <summary>
        ///     Exactly equivalent to {@code fromByteArray(bytes, 0)}.
        /// </summary>
        /// <param name="bytes">The byte array to decode to a long</param>
        /// <returns>The decoded long value</returns>
        public static long FromByteArray(byte[] bytes)
        {
            return FromByteArray(bytes, 0);
        }

        /// <summary>
        ///     Decode a long from array {@code bytes} at {@code offset}.
        ///     Bytes from array {@code bytes[offset]} up to and including
        ///     {@code bytes[offset + Long.BYTES - 1]} will be read from
        ///     array {@code bytes}.
        /// </summary>
        /// <param name="bytes">The byte array to decode to a long</param>
        /// <param name="offset">The offset within the array to start decoding</param>
        /// <returns>The decoded long value</returns>
        public static long FromByteArray(byte[] bytes, int offset)
        {
            if (bytes == null)            
                throw new ArgumentNullException(nameof(bytes));
            

            long value = 0;
            for (int b = 0; b < sizeof(long); b++)
            {
                value <<= 8;
                value |= bytes[offset + b] & 0xFFL;
            }
            return value;
        }

        /// <summary>
        ///     Assemble a {@code long} value from it's component bytes.
        /// </summary>
        /// <param name="b0">Most significant byte</param>
        /// <param name="b1">Next most significant byte</param>
        /// <param name="b2">&hellip;</param>
        /// <param name="b3">&hellip;</param>
        /// <param name="b4">&hellip;</param>
        /// <param name="b5">&hellip;</param>
        /// <param name="b6">Next least significant byte</param>
        /// <param name="b7">Least significant byte</param>
        /// <returns>The {@code long} value represented by the arguments.</returns>
        public static long FromBytes(byte b0, byte b1, byte b2, byte b3, byte b4, byte b5, byte b6, byte b7)
        {
            return (b0 & 0xFFL) << 56 | (b1 & 0xFFL) << 48 | (b2 & 0xFFL) << 40 | (b3 & 0xFFL) << 32
                 | (b4 & 0xFFL) << 24 | (b5 & 0xFFL) << 16 | (b6 & 0xFFL) << 8 | (b7 & 0xFFL);
        }

        /// <summary>
        ///     Compares two {@code long} values numerically treating the values
        ///     as unsigned.
        /// </summary>
        /// <param name="x">the first {@code long} to compare</param>
        /// <param name="y">the second {@code long} to compare</param>
        /// <returns>
        ///     than {@code 0} if {@code x < y} as unsigned values; and
        ///     a value greater than {@code 0} if {@code x > y} as
        ///     unsigned values
        /// </returns>
        public static int CompareUnsigned(long x, long y)
        {
            var l = x + Int64.MinValue;
            return l.CompareTo(y + Int64.MinValue);
        }
    }
}
