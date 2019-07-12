

using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Security;
using System.Linq;

namespace j0n6s.RadixDlt.Identity
{
    public class ECKeyPair
    {
        private const string CURVEALGO = "secp256k1";
        private const string KEYPAIRALGO = "ECDSA";

        public ECPublicKey PublicKey { get; }
        public ECPrivateKey PrivateKey { get; }

        public ECKeyPair(ECPrivateKey privateKey, ECPublicKey publicKey)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }

        public ECKeyPair(byte[] privateKey, byte[] publicKey)
        {
            PublicKey = new ECPublicKey(publicKey);
            PrivateKey = new ECPrivateKey(privateKey);
        }

    }
}