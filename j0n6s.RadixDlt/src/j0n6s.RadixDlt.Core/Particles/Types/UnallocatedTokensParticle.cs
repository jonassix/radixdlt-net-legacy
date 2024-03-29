﻿using System;
using System.Collections.Generic;
using System.Text;
using j0n6s.RadixDlt.Identity;
using j0n6s.RadixDlt.Primitives;

namespace j0n6s.RadixDlt.Particles.Types
{
    /// <summary>
    ///     A particle which represents an amount of unallocated tokens which can be minted.
    /// </summary>
    public class UnallocatedTokensParticle : Particle, IAccountable, IOwnable
    {

        public HashSet<RadixAddress> Addresses => new HashSet<RadixAddress>() { Address };
        public RadixAddress Address => TokenDefinitionReference.Address;

        public RRI TokenDefinitionReference { get; }
        public UInt256 Granularity { get; }
        public long Nonce { get; }
        public UInt256 Amount { get; }
        public IDictionary<TokenTransition, TokenPermission> TokenPermissions { get; }

        public UnallocatedTokensParticle(RRI tokenDefinitionReference, UInt256 granularity, long nonce, UInt256 amount, IDictionary<TokenTransition, TokenPermission> tokenPermissions)
            : base(tokenDefinitionReference.Address.EUID)
        {
            TokenDefinitionReference = tokenDefinitionReference;
            Granularity = granularity;
            Nonce = nonce;
            Amount = amount;
            TokenPermissions = tokenPermissions;
        }
    }
}
