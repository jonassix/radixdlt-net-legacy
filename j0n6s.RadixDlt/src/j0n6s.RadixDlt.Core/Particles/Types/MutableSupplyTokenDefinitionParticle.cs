using System;
using System.Collections.Generic;
using System.Text;
using j0n6s.RadixDlt.Identity;
using j0n6s.RadixDlt.Identity.Managers;
using j0n6s.RadixDlt.Primitives;

namespace j0n6s.RadixDlt.Particles.Types
{
    public class MutableSupplyTokenDefinitionParticle : TokenDefinitionParticle
    {
        public string Symbol { get; private set; }
        public IDictionary<TokenTransition,TokenPermission> TokenPermissions { get; private set; }

        public MutableSupplyTokenDefinitionParticle(RRI rRI, string name, string description, UInt256 granularity, string iconUrl, string symbol, IDictionary<TokenTransition, TokenPermission> tokenPermissions)
            : base (rRI,name,description,granularity,iconUrl)
        {
            Symbol = symbol;
            TokenPermissions = tokenPermissions;
        }
    }
}
