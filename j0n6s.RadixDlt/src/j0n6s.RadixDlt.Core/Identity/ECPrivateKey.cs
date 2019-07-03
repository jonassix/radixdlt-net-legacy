using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Identity
{
    public class ECPrivateKey : IBase64Encoded
    {
        private readonly byte[] _privateKey;

        public string Base64 => Convert.ToBase64String(_privateKey);

        public byte[] Base64Array
        {
            get
            {
                var arr = new byte[_privateKey.Length];
                _privateKey.CopyTo(arr, 0);
                return arr;
            }
        }

        public ECPrivateKey(byte[] privateKey)
        {
            _privateKey = new byte[privateKey.Length];
            Array.Copy(privateKey, _privateKey, privateKey.Length);
        }


    }
}
