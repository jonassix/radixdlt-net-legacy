

using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace j0n6s.RadixDlt.Identity
{
    public class ECKeyPair
    {
        private const string CURVEALGO = "secp256k1";
        private const string KEYPAIRALGO = "ECDSA";

        public ECPublicKey PublicKey { get; }
        public ECPrivateKey PrivateKey { get; }

        public ECKeyPair(ECPublicKey publicKey , ECPrivateKey privateKey)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }

        public ECKeyPair(byte[] publicKey, byte[] privateKey)
        {
            PublicKey = new ECPublicKey(publicKey);
            PrivateKey = new ECPrivateKey(privateKey);
        }

        public static ECKeyPair GenerateRandomKeyPair()
        {
            var curve = ECNamedCurveTable.GetByName(CURVEALGO);
            var domainParams = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H, curve.GetSeed());

            var secureRandom = new SecureRandom();
            var keyParams = new ECKeyGenerationParameters(domainParams, secureRandom);

            var generator = new ECKeyPairGenerator(KEYPAIRALGO);
            generator.Init(keyParams);
            var keyPair = generator.GenerateKeyPair();

            var privateKey = (keyPair.Private as ECPrivateKeyParameters).D.ToByteArrayUnsigned();
            var publicKey = (keyPair.Public as ECPublicKeyParameters).Q.GetEncoded();

            return new ECKeyPair(publicKey,privateKey);
        }
    }
}