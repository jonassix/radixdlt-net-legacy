using j0n6s.RadixDlt.Utils;
using Shouldly;
using System;
using Xunit;

namespace j0n6s.RadixDlt.Core.Tests
{
    public class Base58_Tests
    {
        private const string validBase58 = "JF42V22No24ekweEbLXa872yWydh2r2yM89hyq2pxjCmcQTwUPo";

        [Fact]
        public void Base58FromTo_tests()
        {
            var bA = Base58.FromBase58(validBase58);

            var base58str = Base58.ToBase58(bA);

            base58str.ShouldBe(validBase58);
        }
    }
}
