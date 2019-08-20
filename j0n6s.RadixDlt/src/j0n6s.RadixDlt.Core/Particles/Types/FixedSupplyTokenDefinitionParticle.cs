﻿using System;
using System.Collections.Generic;
using System.Text;
using j0n6s.RadixDlt.Identity;
using j0n6s.RadixDlt.Primitives;

namespace j0n6s.RadixDlt.Particles.Types
{
    public class FixedSupplyTokenDefinitionParticle : Particle, IIdentifiable, IOwnable
    {
        public RRI RRI { get; }
        public RadixAddress Address => RRI.Address;
        public string Name { get; }
        public string Description { get; }
        public UInt256 Supply { get; }
        public UInt256 Granularity { get; }
        public string IconUrl { get; }

        public FixedSupplyTokenDefinitionParticle(RRI rRI, string name, string description, UInt256 supply, UInt256 granularity, string iconUrl)
            : base (rRI.Address.EUID)
        {
            RRI = rRI;
            Name = name;
            Description = description;
            Supply = supply;
            Granularity = granularity;
            IconUrl = iconUrl;
        }
    }
}
