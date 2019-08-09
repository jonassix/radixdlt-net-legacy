using j0n6s.RadixDlt.Primitives;
using System;
using System.Globalization;

namespace j0n6s.RadixDlt.Identity
{
    public class EUID
    {
        public static readonly EUID ZERO = new EUID(0);
        public static readonly EUID ONE = new EUID(1);
        public static readonly EUID TWO = new EUID(2);

        public const int BYTES = 16;

        private readonly Int128 _value;


        public EUID(long v)
        {
            _value = new Int128(v);
        }

        /// <summary>
        ///     convert a hex representation of a int128 to int128
        /// </summary>
        /// <param name="s"></param>
        public EUID(string s)
        {
            Int128.TryParse(s,NumberStyles.HexNumber, NumberFormatInfo.CurrentInfo, out _value);
        }

        public EUID(Int128 n)
        {
            _value = n;
        }

        public EUID(byte[] bytes)
        {
            byte[] newBytes = Extend(bytes);
            long high = Longs.FromByteArray(newBytes, 0);
            long low = Longs.FromByteArray(newBytes, 8);

            _value = Int128.Create(low, high);
        }


        private static byte[] Extend(byte[] bytes)
        {
            if (bytes.Length >= BYTES)
            {
                return bytes;
            }

            byte[] newBytes = new byte[BYTES];
            int newPos = BYTES - bytes.Length;
            // Sign extension            
            newBytes.Fill(0, newPos, (bytes[0] < 0) ? (byte)0xFF : (byte)0x00);            
            Array.Copy(bytes, 0, newBytes, newPos, bytes.Length);
            return newBytes;
        }

        public long GetShard()
        {
            return _value.High;
        }

        public long GetLow()
        {
            return _value.Low;
        }

        public override string ToString()
        {
            return _value.ToString("x2");
        }
    }
}