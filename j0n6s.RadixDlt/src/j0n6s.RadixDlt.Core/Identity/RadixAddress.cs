using j0n6s.RadixDlt.EllipticCurve;
using j0n6s.RadixDlt.Hashing;
using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Identity
{
    public class RadixAddress
    {
        private readonly string _addressBase58;
        private readonly ECPublicKey _pubKey;

        /// <summary>
        ///     Create a RadixAddres from a base58 string
        /// </summary>
        /// <param name="addressBase58"></param>
        public RadixAddress(string addressBase58)
        {
            byte[] raw = Base58Encoding.Decode(addressBase58);
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

        /// <summary>
        ///     Create a RadixAddress from a Elliptic Curve Public Key
        /// </summary>
        /// <param name="magic"></param>
        /// <param name="publicKey"></param>
        public RadixAddress(int magic, ECPublicKey publicKey)
        {
            if (publicKey == null)            
                throw new ArgumentNullException(nameof(publicKey));

            if (publicKey.Length() != 33)
                throw new ArgumentException($"publickey must be 33 in lenghth but was : {publicKey.Length()}");

            byte[] addressBytes = new byte[1 + publicKey.Length() + 4];
            // Universe magic byte
            addressBytes[0] = (byte)(magic & 0xff);
            publicKey.CopyPublicKey(addressBytes, 1);

            // Checksum
            byte[] check = RadixHash.Of(addressBytes, 0, publicKey.Length() + 1).ToByteArray();
            Array.Copy(check, 0, addressBytes, publicKey.Length() + 1, 4);

            //_addressBase58 = Base58.ToBase58(addressBytes);
            _addressBase58 = Base58Encoding.Encode(addressBytes);
            _pubKey = publicKey;
        }

        public override string ToString()
        {
            return _addressBase58;
        }

        public virtual ECPublicKey GetECPublicKey()
        {
            return _pubKey;
        }

        //public EUID GetEUID()
        //{
        //    return _pubKey.GetEUID();
        //}
    }
}
