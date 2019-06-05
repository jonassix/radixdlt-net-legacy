using j0n6s.RadixDlt.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Identity
{
    public class RadixAddress
    {
        private readonly string _addressBase58;
        private readonly ECPublicKey _pubKey;

        public RadixAddress(string addressBase58)
        {
            byte[] raw = Base58.FromBase58(addressBase58);
            RadixHash check = RadixHash.Of(raw, 0, raw.Length - 4);

            for (int i = 0; i < 4; ++i)
            {
                if (check.Get(i) != raw[raw.Length - 4 + i])
                {
                    throw new ArgumentException("Address " + addressBase58 + " checksum mismatch");
                }
            }

            byte[] publicKey = new byte[raw.Length - 5];
            Array.Copy(raw, 1, publicKey, 0, raw.Length - 5);

            _addressBase58 = addressBase58;
            _pubKey = new ECPublicKey(publicKey);

        }

        public RadixAddress(int magic, ECPublicKey publicKey)
        {
            if (publicKey == null)            
                throw new ArgumentNullException(nameof(publicKey));

            if (publicKey.Length() != 33)
                throw new ArgumentException($"publickey must be 33 in lenghth but was : {publicKey.Length()}");

            byte[] addressBytes = new byte[1 + publicKey.Length() + 4];
            addressBytes[0] = (byte)(magic & 0xff);
        }

    }
}
