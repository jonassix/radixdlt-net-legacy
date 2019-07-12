using j0n6s.RadixDlt.Identity;
using System;
using System.Linq;

namespace ManualTester
{
    class Program
    {
        static void Main(string[] args)
        {

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




        static string ToHex(byte[] data) => String.Concat(data.Select(x => x.ToString("x2")));
    }
}
