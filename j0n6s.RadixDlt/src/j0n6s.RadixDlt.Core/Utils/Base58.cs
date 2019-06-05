using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace j0n6s.RadixDlt.Utils
{
    public class Test
    {

    }
    public static class Base58
    {
        private const string B58CharSet = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
        private static char[] B58 => B58CharSet.ToCharArray();
        private static readonly int[] R58 = Enumerable.Repeat(-1, 256).ToArray();

        static Base58()
        {
            for (int i = 0; i < B58.Length; ++i)
            {
                R58[B58[i]] = i;
            }
        }

        // Encodes the specified byte array into a String using the Base58 encoding scheme
        public static string ToBase58(byte[] b)
        {
            if (b.Length == 0)
                return "";

            var lz = 0;

            while (lz < b.Length && b[lz] == 0)            
                ++lz;            

            var s = new StringBuilder();
            var n = new BigInteger(b);
            
            while (n.CompareTo(BigInteger.Zero) > 0)
            {
                n = BigInteger.DivRem(n, new BigInteger(BitConverter.GetBytes(58)), out BigInteger remainder);
                var digit = B58[(int)remainder];

                s.Append(digit);
            }

            while (lz > 0)
            {
                --lz;
                s.Append("1");
            }
            return new string(s.ToString().Reverse().ToArray());
        }

        public static byte[] FromBase58(string s)
        {
            try
            {
                var leading = true;
                var lz = 0;
                var b = BigInteger.Zero;
                foreach (char c in s.ToCharArray())
                {
                    if (leading && c == '1')                    
                        ++lz;                    
                    else
                    {
                        leading = false;                        
                        b = BigInteger.Multiply(b, new BigInteger(58));
                        b = BigInteger.Add(b, new BigInteger(R58[c]));                        
                    }
                }
                byte[] encoded = b.ToByteArray();
                if (encoded[0] == 0)
                {
                    if (lz > 0)                    
                        --lz;                    
                    else
                    {
                        var e = new byte[encoded.Length - 1];                        
                        Array.Copy(encoded, 1, e, 0, e.Length);
                        encoded = e;
                    }
                }
                var result = new byte[encoded.Length + lz];
                Array.Copy(encoded, 0, result, lz, encoded.Length);
                
                return result;
            }
            catch (IndexOutOfRangeException e)
            {
                throw new ArgumentException($"Invalid character in address : causes {e.Message}");
            }
        }
    }
}
