using j0n6s.RadixDlt.Identity;
using System;
using System.Linq;

namespace ManualTester
{
    class Program
    {
        static void Main(string[] args)
        {
            RadixAddress address = new RadixAddress("JF42V22No24ekweEbLXa872yWydh2r2yM89hyq2pxjCmcQTwUPo");

            Console.WriteLine($"addres is {address}");
            Console.WriteLine($"pubkey is {address.GetECPublicKey()}");
            Console.WriteLine($"euid is {address.GetEUID()}");            
        }





        static string ToHex(byte[] data) => String.Concat(data.Select(x => x.ToString("x2")));
    }
}
