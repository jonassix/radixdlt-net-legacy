using j0n6s.RadixDlt.EllipticCurve;
using j0n6s.RadixDlt.EllipticCurve.Managers;
using j0n6s.RadixDlt.Identity;
using j0n6s.RadixDlt.Identity.Managers;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace j0n6s.RadixDlt.Core.Tests.Crypto
{
    public class ECKeyManager_Tests
    {
        private readonly IECKeyManager _manager;

        public ECKeyManager_Tests()
        {
            _manager = new ECKeyManager();
        }

        [Fact]
        public void Should_GenerateUnique_Keys()
        {
            var keyPairs = new List<ECKeyPair>();

            var i = 0;
            while (i++ < 100)
                keyPairs.Add(_manager.GetRandomKeyPair());

            foreach(var pair in keyPairs)
            {                
                var a = keyPairs.Where(ec =>  
                    ec.PrivateKey.Base64 == pair.PrivateKey.Base64 ||
                    ec.PublicKey.Base64 == pair.PublicKey.Base64
                ).ToList();

                //there should only be one match, aka himself
                a.Count.ShouldBe(1);
            }
        }


        [Fact]
        public void Should_CreateTheSame_KeyPair()
        {
            var pair = _manager.GetRandomKeyPair();
            var pair2 = _manager.GetKeyPair(pair.PrivateKey);

            pair2.PublicKey.Base64.ShouldBe(pair2.PublicKey.Base64);
            _manager.VerifyKeyPair(pair2).ShouldBe(true);
        }

        [Fact]
        public void Should_CreateValid_ECSignature()
        {
            var toSign = "Hello World!";
            var pair = _manager.GetRandomKeyPair();

            var signature = _manager.GetECSignature(pair.PrivateKey, Encoding.ASCII.GetBytes(toSign));
            _manager.VerifyECSignature(pair.PublicKey, signature, Encoding.ASCII.GetBytes(toSign)).ShouldBe(true);
            _manager.VerifyECSignature(pair.PublicKey, signature, Encoding.ASCII.GetBytes(toSign+" ")).ShouldBe(false);
        }

        [Fact]
        public void UnEncrypted_And_DeCrypted_ShouldBeTheSame()
        {
            //arrange
            var keypair = _manager.GetRandomKeyPair();
            var msg = "This is a message we want to encrypt";
            var toEncrypt = Encoding.UTF8.GetBytes(msg);

            //act
            var encrypted = _manager.Encrypt(keypair.PublicKey, toEncrypt);
            var decrypted = _manager.Decrypt(keypair.PrivateKey, encrypted);

            //assert
            msg.ShouldBe(Encoding.UTF8.GetString(decrypted));
            msg.ShouldNotBe(Encoding.UTF8.GetString(encrypted));
        }
    }
}
