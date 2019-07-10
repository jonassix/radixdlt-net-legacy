using j0n6s.RadixDlt.Identity;
using j0n6s.RadixDlt.Utils;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System;
using System.Linq;
using System.Text;

namespace ManualTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            var msg = "Hello World!";
            var privateKey = "68040878110175628235481263019639686";
            var prInt = new BigInteger(privateKey);
            var ECkPair = ECKeyPair.GenerateKeyPair(new ECPrivateKey(prInt.ToByteArray()));
            
            var pubkeystr = Base58Encoding.Encode(ECkPair.PublicKey.Base64Array);

            Console.WriteLine($"privkey : {privateKey}");
            Console.WriteLine($"pubkey : {pubkeystr}");

            var signature = GetSignature(privateKey, msg);
            Console.WriteLine(signature);

            var valid = VerifySignature(msg, pubkeystr, signature);
            Console.WriteLine(valid);

            Console.WriteLine("alternate way--------");
            var signature2 = GetSignatureAlt(ECkPair.PrivateKey.Base64Array, Encoding.ASCII.GetBytes(msg));
        }

        public static bool VerifySignature(string message, string publicKey, string signature)
        {
            var curve = SecNamedCurves.GetByName("secp256k1");
            var domain = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H);
            var publicKeyBytes = Base58Encoding.Decode(publicKey);
            var q = curve.Curve.DecodePoint(publicKeyBytes);
            var keyParameters = new ECPublicKeyParameters(q,domain);
            ISigner signer = SignerUtilities.GetSigner("SHA-256withECDSA");

            signer.Init(false, keyParameters);
            signer.BlockUpdate(Encoding.ASCII.GetBytes(message), 0, message.Length);
            var signatureBytes = Base58Encoding.Decode(signature);

            return signer.VerifySignature(signatureBytes);
        }

        private static void GeneratingRandomRadixAddresses()
        {
            var pair = ECKeyPair.GenerateRandomKeyPair();
            var rAdr = new RadixAddress(-1355743231, pair.PublicKey);
            Console.WriteLine(rAdr.ToString());
            Console.WriteLine(new RadixAddress(-1355743231, ECKeyPair.GenerateRandomKeyPair().PublicKey));
            Console.WriteLine(new RadixAddress(-1355743231, ECKeyPair.GenerateRandomKeyPair().PublicKey));
            Console.WriteLine(new RadixAddress(-1355743231, ECKeyPair.GenerateRandomKeyPair().PublicKey));
            Console.WriteLine(new RadixAddress(-1355743231, ECKeyPair.GenerateRandomKeyPair().PublicKey));
            Console.WriteLine(new RadixAddress(-1355743231, ECKeyPair.GenerateRandomKeyPair().PublicKey));
            Console.WriteLine(new RadixAddress(-1355743231, ECKeyPair.GenerateRandomKeyPair().PublicKey));
            Console.WriteLine(new RadixAddress(-1355743231, ECKeyPair.GenerateRandomKeyPair().PublicKey));
            Console.ReadLine();
        }

        public static string GetSignature(string privateKey, string message)
        {

            var curve = SecNamedCurves.GetByName("secp256k1");

            var domain = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H);

            var keyParameters = new ECPrivateKeyParameters(new BigInteger(privateKey), domain);

            ISigner signer = SignerUtilities.GetSigner("SHA-256withECDSA");
            signer.Init(true, keyParameters);
            signer.BlockUpdate(Encoding.ASCII.GetBytes(message), 0, message.Length);
            var signature = signer.GenerateSignature();           

            return Base58Encoding.Encode(signature);
        }

        public static ECSignature GetSignatureAlt(byte[] privatekey, byte[] message)
        {
            //need to creat this as parameters
            bool beDeterministic = true;
            bool enforceLowS = true;

            var curve = SecNamedCurves.GetByName("secp256k1");
            var domain = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H);

            
            IDsaKCalculator kCalculator;

            if (beDeterministic)
                kCalculator = new HMacDsaKCalculator(new Sha256Digest());
            else kCalculator = new RandomDsaKCalculator();

            ECDsaSigner signer = new ECDsaSigner(kCalculator);
            signer.Init(true, new ECPrivateKeyParameters(new BigInteger(1, privatekey), domain));

            BigInteger[] components = signer.GenerateSignature(message);

            BigInteger r = components[0];
            BigInteger s = components[1];

            BigInteger curveOrder = domain.N;
            BigInteger halvCurveOrder = curveOrder.ShiftRight(1);

            bool sIsLow = s.CompareTo(halvCurveOrder) <= 0;

            if (enforceLowS && !sIsLow)
            {
                s = curveOrder.Subtract(s);
            }

            return new ECSignature(r, s);
        }

        static string ToHex(byte[] data) => String.Concat(data.Select(x => x.ToString("x2")));
    }
}
