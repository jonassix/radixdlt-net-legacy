namespace j0n6s.RadixDlt.Utils.Primitives
{
    /// <summary>
    ///     Utilities for manipulating primitive {@code int} values.
    /// </summary>
    public sealed class Ints
    {
        private Ints() { }

        /// <summary>
        ///     Create a byte array of length {@link Integer#BYTES}, and
        ///     populate it with {@code value} in big-endian order.
        /// </summary>
        /// <param name="value">The value to convert</param>
        /// <returns>The resultant byte array.</returns>
        public static byte[] ToByteArray(int value)
        {
            return CopyTo(value, new byte[sizeof(int)], 0);
        }

        /// <summary>
        ///     Copy the byte value of {@code value} into {@code bytes}
        ///     starting at {@code offset}.  A total of {@link Integer#BYTES}
        ///     will be written to {@code bytes}.
        /// </summary>
        /// <param name="value">The value to convert</param>
        /// <param name="bytes">The array to write the value into</param>
        /// <param name="offset">The offset at which to write the value</param>
        /// <returns>The value of {@code bytes}</returns>
        public static byte[] CopyTo(int value, byte[] bytes, int offset)
        {
            if (bytes == null)
                throw new System.ArgumentNullException(nameof(bytes));
            

            for (int i = offset + sizeof(int) - 1; i >= offset; i--)
            {
                bytes[i] = (byte)(value & 0xFF);
                value = (int)((uint)value >> 8);
            }
            return bytes;
        }

        /// <summary>
        ///     Exactly equivalent to {@code fromByteArray(bytes, 0)}.
        /// </summary>
        /// <param name="bytes">The byte array to decode to an integer</param>
        /// <returns>The decoded integer value</returns>
        public static int FromByteArray(byte[] bytes)
        {
            return FromByteArray(bytes, 0);
        }

        /// <summary>
        ///     Decode an integer from array {@code bytes} at {@code offset}.
        ///     Bytes from array {@code bytes[offset]} up to and including
        ///     {@code bytes[offset + Integer.BYTES - 1]} will be read from
        ///     array {@code bytes}.
        /// </summary>
        /// <param name="bytes">The byte array to decode to an integer</param>
        /// <param name="offset">The offset within the array to start decoding</param>
        /// <returns>The decoded integer value</returns>
        public static int FromByteArray(byte[] bytes, int offset)
        {
            if (bytes == null)            
                throw new System.ArgumentNullException(nameof(bytes));
            

            int value = 0;
            for (int b = 0; b < sizeof(int); b++)
            {
                value <<= 8;
                value |= bytes[offset + b] & 0xFF;
            }

            return value;
        }

        /// <summary>
        ///     Assemble an {@code int} value from it's component bytes.
        /// </summary>
        /// <param name="b0">Most significant byte</param>
        /// <param name="b1">Next most significant byte</param>
        /// <param name="b2">Next least significant byte</param>
        /// <param name="b3">Least significant byte</param>
        /// <returns>The {@code int} value represented by the arguments.</returns>
        public static int FromBytes(byte b0, byte b1, byte b2, byte b3)
        {
            return b0 << 24 | (b1 & 0xFF) << 16 | (b2 & 0xFF) << 8 | (b3 & 0xFF);
        }
    }
}
