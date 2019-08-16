using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using j0n6s.RadixDlt.Identity;
using j0n6s.RadixDlt.Identity.Managers;

namespace j0n6s.RadixDlt.Particles.Types
{
    public class UniqueParticle : Particle , IIdentifiable
    {
        public RRI RRI => new RRI(Address, Name);
        public string Name { get;  }
        public RadixAddress Address { get;  }
        public long Nonce { get; }

        public UniqueParticle(RadixAddress address, string name) 
            : base(new EUIDManager().GetEUID(address))
        {
            Name = name;
            Address = address;
            Nonce = RandomGenerator.GetRandomLong();
        }
        
    }
}
