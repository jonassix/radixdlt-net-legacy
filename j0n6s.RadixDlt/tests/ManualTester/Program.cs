using j0n6s.RadixDlt.Identity;
using j0n6s.RadixDlt.Identity.Managers;
using j0n6s.RadixDlt.Utils.Primitives;
using System;
using System.Linq;
using System.Text;

namespace ManualTester
{
    class Program
    {
        static void Main(string[] args)
        {
            IECKeyManager keyman = new ECKeyManager();

            var keypair = keyman.GetRandomKeyPair();

            var msg = "toencrypt";

            var encrypteddata = keyman.Encrypt(keypair.PublicKey, Encoding.UTF8.GetBytes(msg));

            var decrypteddata = Encoding.UTF8.GetString( keyman.Decrypt(keypair.PrivateKey, encrypteddata));

            Console.WriteLine(decrypteddata);
        }





        static string ToHex(byte[] data) => String.Concat(data.Select(x => x.ToString("x2")));
    }
}
