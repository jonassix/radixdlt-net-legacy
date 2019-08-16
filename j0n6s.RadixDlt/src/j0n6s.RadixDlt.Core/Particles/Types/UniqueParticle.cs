using System;
using System.Collections.Generic;
using System.Text;
using j0n6s.RadixDlt.Identity;

namespace j0n6s.RadixDlt.Particles.Types
{
    public class UniqueParticle : Particle , IIdentifiable
    {
        public RRI RRI { get; protected set; }
        public string Name => RRI.Name;
        public long Nonce { get; }

        public UniqueParticle(RRI rri , EUID destination) : base(destination)
        {
            RRI = rri;
            throw new NotImplementedException("todo : rng nonce");
        }

        
    }
}
