using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace j0n6s.RadixDlt
{
    public static class RandomGenerator
    {
        public static byte[] GetRandomBytes(int size)
        {
            using (var provider = new RNGCryptoServiceProvider())
            {
                var byteArray = new byte[size];
                provider.GetBytes(byteArray);
                return byteArray;
            }
        }

        public static long GetRandomLong()
        {
            return BitConverter.ToInt64(GetRandomBytes(8), 0);
        }
    }
}
