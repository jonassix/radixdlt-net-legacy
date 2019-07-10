

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

        /// <summary>
        ///     Generate a Random KeyPair
        /// </summary>
        /// <returns></returns>
        public static ECKeyPair GenerateRandomKeyPair(bool compressed = true)
        {
            var curve = ECNamedCurveTable.GetByName(CURVEALGO);
            var domainParams = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H, curve.GetSeed());

            var secureRandom = new SecureRandom();
            var keyParams = new ECKeyGenerationParameters(domainParams, secureRandom);

            var generator = new ECKeyPairGenerator(KEYPAIRALGO);           
            generator.Init(keyParams);
            var keyPair = generator.GenerateKeyPair();


            var privateKey = (keyPair.Private as ECPrivateKeyParameters).D.ToByteArray();
            //var privateKey = (keyPair.Private as ECPrivateKeyParameters).D.ToByteArrayUnsigned();
            var publicKey = (keyPair.Public as ECPublicKeyParameters).Q.GetEncoded(compressed);

            return new ECKeyPair(privateKey, publicKey);
        }

        /// <summary>
        ///     Generate a public key from a private key
        /// </summary>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static ECKeyPair GenerateKeyPair(ECPrivateKey privateKey, bool compressed = true)
        {
            var curve = ECNamedCurveTable.GetByName(CURVEALGO);
            var domainParams = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H, curve.GetSeed());

            BigInteger d = new BigInteger(privateKey.Base64Array);
            ECPoint q = domainParams.G.Multiply(d);

            var publicParams = new ECPublicKeyParameters(q, domainParams);
            var pubkey = new ECPublicKey(publicParams.Q.GetEncoded(compressed));

            return new ECKeyPair(privateKey, pubkey);
        }        


        /// <summary>
        ///     Verify if a publickey and privatekey belong together
        /// </summary>
        /// <param name="privKey"></param>
        /// <param name="pubKey"></param>
        /// <returns></returns>
        public static bool VerifyValidKeyPair(ECPrivateKey privKey, ECPublicKey pubKey)
        {
            var pair = GenerateKeyPair(privKey);
            
            return pair.PublicKey.Base64Array.SequenceEqual(pubKey.Base64Array);
        }

        public static bool VerifyValidKeyPair(ECKeyPair keyPair)
        {
            return VerifyValidKeyPair(keyPair.PrivateKey, keyPair.PublicKey);
        }
    }
}