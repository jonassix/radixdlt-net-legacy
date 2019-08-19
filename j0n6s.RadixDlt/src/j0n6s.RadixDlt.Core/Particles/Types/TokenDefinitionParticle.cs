using System;
using System.Collections.Generic;
using System.Text;
using j0n6s.RadixDlt.Identity;

namespace j0n6s.RadixDlt.Particles.Types
{
    public class TokenDefinitionParticle : Particle  , IIdentifiable, IOwnable
    {
        public RRI RRI => new RRI(Address, Symbol);
        public RadixAddress Address { get; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public TokenDefinitionParticle(EUID destination) : base(destination)
        {

        }


    }
}
