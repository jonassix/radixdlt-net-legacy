﻿using j0n6s.RadixDlt.Identity;

namespace j0n6s.RadixDlt.Particles.Types
{
    public class UniqueParticle : Particle , IIdentifiable
    {
        public RRI RRI => new RRI(Address, Name);
        public string Name { get;  }
        public RadixAddress Address { get;  }
        public long Nonce { get; }

        public UniqueParticle(RadixAddress address, string name) 
            : base(address.EUID)
        {
            Name = name;
            Address = address;
            Nonce = RandomGenerator.GetRandomLong();
        }
        
    }
}
