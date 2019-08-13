using j0n6s.RadixDlt.EllipticCurve.Managers;
using PeterO.Cbor;
using System;
using System.Linq;
using System.Text;

namespace ManualTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapper = new DsonMapper();
            var bytes = mapper.Test();
            var dummy = mapper.Test2(bytes);

            Console.WriteLine(dummy.PropB);
        }


        public class DsonMapper
        {

            public byte[] Test()
            {
                var dummy = new AClass()
                {
                    PropA = 1,
                    PropB = 5
                };

                var cborTest = CBORObject.FromObject(dummy);
                return cborTest.EncodeToBytes();
            }

            public AClass Test2(byte[] bytes)
            {
                var cbortest = CBORObject.DecodeFromBytes(bytes);
                return cbortest.ToObject<AClass>();
            }
        }

        public class AClass
        {
            public int PropA { get; set; }
            public int PropB { get; set; }
        }
    }
}
