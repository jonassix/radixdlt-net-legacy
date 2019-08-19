using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using j0n6s.RadixDlt.Identity;
using j0n6s.RadixDlt.Identity.Managers;

namespace j0n6s.RadixDlt.Particles.Types
{
    public class RriParticle : Particle , IAccountable
    {
        public RRI RRI { get; protected set; }        
        public long Nonce { get; }

        public HashSet<RadixAddress> Addresses => new HashSet<RadixAddress>() { RRI.Address };

        public RriParticle(RRI rri) : base(rri.Address.EUID)
        {
            RRI = rri;
            Nonce = 0;
        }
        
    }
}
