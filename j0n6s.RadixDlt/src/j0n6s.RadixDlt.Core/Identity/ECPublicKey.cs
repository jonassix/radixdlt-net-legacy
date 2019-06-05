﻿using j0n6s.RadixDlt.Utils;
using System;

namespace j0n6s.RadixDlt.Identity
{
    public class ECPublicKey : IBase64Encoded
    {
        private readonly byte[] _publicKey;

        public string Base64 => Convert.ToBase64String(_publicKey);

        public byte[] Base64Array{
            get {
                var arr = new byte[_publicKey.Length];
                _publicKey.CopyTo(arr, 0);                
                return arr;
            }
        }

        public ECPublicKey(byte[] publicKey)
        {
            publicKey.CopyTo(_publicKey, publicKey.Length);
        }

      
        public virtual EUID GetEUID()
        {
            return RadixHash.Of(_publicKey).ToEUID();
        }

        public virtual ECKeyPair GetECKeyPair()
        {
            throw new System.NotImplementedException();
        }

        public virtual bool Verify(byte[] data, ECSignature signature)
        {
            throw new NotImplementedException();
        }

        public virtual byte[] Encrypt(byte[] data)
        {
            throw new NotImplementedException();
        }

        public virtual int Length()
        {
            return _publicKey.Length;
        }

        public virtual void CopyPublicKey(byte[] dest, int destPos)
        {
            Array.Copy(_publicKey, 0, dest, destPos, dest.Length);
        }
    }
}