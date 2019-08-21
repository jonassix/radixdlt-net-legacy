using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt
{
    public class UnencryptedData
    {
        public IDictionary<string,Object> MetaData { get; }
        public byte[] Data { get; }

        public UnencryptedData(IDictionary<string, object> metaData, byte[] data)
        {
            MetaData = metaData;
            Data = data;
        }
    }
}
