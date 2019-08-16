using PeterO.Cbor;
using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt
{
    public class DsonMapper<T>
    {
        public byte[] ToDson(T obj)
        {
            var o = CBORObject.FromObject(obj);            
            return CBORObject.FromObject(obj).EncodeToBytes();
        }
        
        public T ToObject(byte[] data)
        {
            return CBORObject.DecodeFromBytes(data).ToObject<T>();
        }
    }
}
