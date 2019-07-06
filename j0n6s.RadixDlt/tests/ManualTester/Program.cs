using j0n6s.RadixDlt.Identity;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Linq;
using System.Threading;

namespace ManualTester
{
    class Program
    {
        static void Main(string[] args)
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

        //static AsymmetricCipherKeyPair GenerateKeyPair()
        //{
        //    var curve = ECNamedCurveTable.GetByName("secp256k1");
        //    var domainParams = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H, curve.GetSeed());

        //    var secureRandom = new SecureRandom();
        //    var keyParams = new ECKeyGenerationParameters(domainParams, secureRandom);

        //    var generator = new ECKeyPairGenerator("ECDSA");
        //    generator.Init(keyParams);
        //    var keyPair = generator.GenerateKeyPair();

        //    var privateKey = keyPair.Private as ECPrivateKeyParameters;
        //    var publicKey = keyPair.Public as ECPublicKeyParameters;

        //    Console.WriteLine($"Private key: {ToHex(privateKey.D.ToByteArrayUnsigned())}");
        //    Console.WriteLine($"Public key: {ToHex(publicKey.Q.GetEncoded())}");

        //    return keyPair;
        //}
        static string ToHex(byte[] data) => String.Concat(data.Select(x => x.ToString("x2")));
    }
}
