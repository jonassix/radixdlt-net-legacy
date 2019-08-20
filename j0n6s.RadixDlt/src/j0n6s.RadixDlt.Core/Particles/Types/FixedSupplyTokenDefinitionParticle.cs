using System;
using System.Collections.Generic;
using System.Text;
using j0n6s.RadixDlt.Identity;
using j0n6s.RadixDlt.Primitives;

namespace j0n6s.RadixDlt.Particles.Types
{
    public class FixedSupplyTokenDefinitionParticle : TokenDefinitionParticle
    {        
        public UInt256 Supply { get; }

        public FixedSupplyTokenDefinitionParticle(RRI rRI, string name, string description, UInt256 granularity, string iconUrl, UInt256 supply)
            : base (rRI, name, description, granularity, iconUrl)
        {
            Supply = supply;
        }
    }
}
