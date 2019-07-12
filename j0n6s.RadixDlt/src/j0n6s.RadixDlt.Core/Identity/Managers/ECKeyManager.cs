﻿using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace j0n6s.RadixDlt.Identity.Managers
{
    public class ECKeyManager : IECKeyManager
    {
        private const string CURVEALGO = "secp256k1";
        private const string KEYPAIRALGO = "ECDSA";

        public ECSignature GetECSignature(ECPrivateKey privateKey, byte[] data, bool beDeterministic = false, bool enforceLowS = true)
        {
            var curve = SecNamedCurves.GetByName(CURVEALGO);
            var domain = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H);


            IDsaKCalculator kCalculator;

            if (beDeterministic)
                kCalculator = new HMacDsaKCalculator(new Sha256Digest());
            else kCalculator = new RandomDsaKCalculator();

            ECDsaSigner signer = new ECDsaSigner(kCalculator); 
            signer.Init(true, new ECPrivateKeyParameters(new BigInteger(1, privateKey.Base64Array), domain));

            BigInteger[] components = signer.GenerateSignature(data);

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

        public ECKeyPair GetKeyPair(ECPrivateKey privatekey, bool compressed = true)
        {
            var curve = ECNamedCurveTable.GetByName(CURVEALGO);
            var domainParams = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H, curve.GetSeed());

            BigInteger d = new BigInteger(privatekey.Base64Array);
            ECPoint q = domainParams.G.Multiply(d);

            var publicParams = new ECPublicKeyParameters(q, domainParams);
            var pubkey = new ECPublicKey(publicParams.Q.GetEncoded(compressed));

            return new ECKeyPair(privatekey, pubkey);
        }

        public ECKeyPair GetRandomKeyPair(bool compressed = true)
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

        public bool VerifyECSignature(ECPublicKey publicKey, ECSignature signature, byte[] data)
        {
            var curve = ECNamedCurveTable.GetByName(CURVEALGO);
            var domainParams = new ECDomainParameters(curve.Curve, curve.G, curve.N, curve.H, curve.GetSeed());

            ECDsaSigner verifier = new ECDsaSigner();
            verifier.Init(false, new ECPublicKeyParameters(domainParams.Curve.DecodePoint(publicKey.Base64Array), domainParams));

            return verifier.VerifySignature(data, signature.GetR(), signature.GetS());
        }

        public bool VerifyKeyPair(ECKeyPair keyPair)
        {
            var pair = GetKeyPair(keyPair.PrivateKey);

            return pair.PublicKey.Base64Array.SequenceEqual(keyPair.PublicKey.Base64Array);
        }
    }
}
