using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Particles
{
    /// <summary>
    ///     Can only be one Particle instance with the provided identifier
    ///     Has to be a valid Radix Resource Identifier
    /// </summary>
    public interface IIdentifiable : IAccountable
    {
        Rri Id { get; set; }
    }

    /// <summary>
    ///     Transactions involving Particle instances have to add up
    /// </summary>
    public interface IFungible
    {

    }

    /// <summary>
    ///  Particle instances must be stored in a Radix account
    /// </summary>
    public interface IAccountable
    {

    }

    /// <summary>
    /// Only owner of Particle instance can invalidate (i.e. consume) it
    /// </summary>
    public interface IOwnable
    {

    }
}
