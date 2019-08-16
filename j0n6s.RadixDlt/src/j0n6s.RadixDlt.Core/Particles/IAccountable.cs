using j0n6s.RadixDlt.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Particles
{
    public interface IAccountable
    {
        HashSet<RadixAddress> RadixAddresses { get; }
    }
}
