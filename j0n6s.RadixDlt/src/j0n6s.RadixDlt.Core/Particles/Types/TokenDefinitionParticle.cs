﻿using j0n6s.RadixDlt.Identity;
using j0n6s.RadixDlt.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Particles.Types
{
    public abstract class TokenDefinitionParticle :  Particle  , IIdentifiable, IOwnable
    {
        public RRI RRI { get; }
        public RadixAddress Address => RRI.Address;        
        public string Name { get; }
        public string Description { get; }
        public UInt256 Granularity { get; }
        public string IconUrl { get; }

        protected TokenDefinitionParticle(RRI rRI, string name, string description, UInt256 granularity, string iconUrl)
            : base (rRI.Address.EUID)
        {
            RRI = rRI;
            Name = name;
            Description = description;
            Granularity = granularity;
            IconUrl = iconUrl;
        }
    }
}
