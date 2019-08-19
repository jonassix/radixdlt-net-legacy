using System;
using System.Collections.Generic;
using System.Text;
using j0n6s.RadixDlt.Identity;
using j0n6s.RadixDlt.Identity.Managers;
using j0n6s.RadixDlt.Primitives;

namespace j0n6s.RadixDlt.Particles.Types
{
    public class TokenDefinitionParticle : Particle  , IIdentifiable, IOwnable
    {
        public RRI RRI => new RRI(Address, Symbol);
        public RadixAddress Address { get; }
        public string Symbol { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public UInt256 Granularity { get; private set; }
        public string IconUrl { get; private set; }
        public IDictionary<TokenTransition,TokenPermission> TokenPermissions { get; private set; }

        public TokenDefinitionParticle(RadixAddress address, string symbol, string name, string description, UInt256 granularity, string iconUrl, IDictionary<TokenTransition, TokenPermission> tokenPermissions)
            : base (address.EUID)
        {
            Address = address;
            Symbol = symbol;
            Name = name;
            Description = description;
            Granularity = granularity;
            IconUrl = iconUrl;
            TokenPermissions = tokenPermissions;
        }
    }
}
