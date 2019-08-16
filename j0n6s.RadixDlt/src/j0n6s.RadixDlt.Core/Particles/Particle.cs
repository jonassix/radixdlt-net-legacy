using j0n6s.RadixDlt.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Particles
{
    public abstract class Particle
    {
        private readonly HashSet<EUID> _destinations;

        public Particle(EUID destination)
        {
            _destinations = new HashSet<EUID>();
            _destinations.Add(destination);
        }

        public Particle(HashSet<EUID> destinations)
        {
            _destinations = new HashSet<EUID>(destinations);
        }        
    }
}
