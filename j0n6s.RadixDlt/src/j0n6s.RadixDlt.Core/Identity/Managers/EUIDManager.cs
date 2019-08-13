using j0n6s.RadixDlt.EllipticCurve;
using j0n6s.RadixDlt.Hashing;
using j0n6s.RadixDlt.Particles;
using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Identity.Managers
{
    public class EUIDManager
    {
        public virtual EUID GetEUID(byte[] hash)
        {
            return new EUID(ArrayHelpers.SubArray(hash));
        }

        public virtual EUID GetEUID(ECPublicKey pubkey)
        {
            return GetEUID(RadixHash.Of(pubkey.Base64Array).ToByteArray());
        }

        public virtual EUID GetEUID(RadixAddress address)
        {
            return GetEUID(address.GetECPublicKey());
        }

        public virtual EUID GetEUID(Particle particle)
        {
            throw new NotImplementedException();
        }
    }
}
