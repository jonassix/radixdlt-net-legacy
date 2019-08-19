using System;
using System.Collections.Generic;
using System.Text;
using j0n6s.RadixDlt.Identity;
using j0n6s.RadixDlt.Primitives;

namespace j0n6s.RadixDlt.Particles.Types
{
    /// <summary>
    ///    A particle which represents an amount of consumable and consuming, tranferable fungible tokens
    ///  owned by some key owner and stored in an account.
    /// </summary>
    public class TransferrableTokensParticle : Particle , IAccountable, IOwnable
    {
        public RadixAddress Address { get; }
        public HashSet<RadixAddress> Addresses => new HashSet<RadixAddress>() { Address };
        public RRI TokenDefinitionReference { get; }
        public UInt256 Granularity { get; }
        public long Planck { get; }
        public long Nonce { get; }
        public UInt256 Amount { get; set; }
        public IDictionary<TokenTransition, TokenPermission> TokenPermissions { get; }

        public TransferrableTokensParticle(RadixAddress address, RRI tokenDefinitionReference, UInt256 granularity, long planck, long nonce, UInt256 amount, IDictionary<TokenTransition, TokenPermission> tokenPermissions)
            :base(address.EUID)
        {
            Address = address;            
            TokenDefinitionReference = tokenDefinitionReference;
            Granularity = granularity;
            Planck = planck;
            Nonce = nonce;
            Amount = amount;
            TokenPermissions = tokenPermissions;
        }

    }
}
