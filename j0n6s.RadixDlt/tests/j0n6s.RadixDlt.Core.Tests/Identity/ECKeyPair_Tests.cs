using j0n6s.RadixDlt.Identity;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace j0n6s.RadixDlt.Core.Tests.Identity
{
    public class ECKeyPair_Tests
    {
        [Fact]
        public void Should_Have_Matching_PubKey()
        {            
            var i = 0;
            while (i++ < 1000)
            {
                //arrange
                var pair1 = ECKeyPair.GenerateRandomKeyPair();
                var y = 0;
                while (y++ < 5)
                {
                    var pair2 = (ECKeyPair.GenerateKeyPair(pair1.PrivateKey));

                    pair2.ShouldNotBeNull();
                    pair2.PrivateKey.Base64Array.ShouldBe(pair1.PrivateKey.Base64Array);
                    pair2.PrivateKey.Base64.ShouldBe(pair1.PrivateKey.Base64);
                    pair2.PublicKey.Base64.ShouldBe(pair1.PublicKey.Base64);
                    pair2.PublicKey.Base64Array.ShouldBe(pair1.PublicKey.Base64Array);

                    var valid = ECKeyPair.Verify(pair2.PrivateKey, pair1.PublicKey);
                    valid.ShouldBe(true);
                }
            }
        }
    }
}
