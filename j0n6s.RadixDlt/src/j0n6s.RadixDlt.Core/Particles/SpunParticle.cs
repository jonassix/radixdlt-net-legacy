using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Particles
{
    public class SpunParticle<T>
        where T : Particle
    {
        public Particle Particle { get; }
        public Spin Spin { get; }

        public SpunParticle(Particle particle, Spin spin)
        {
            Particle = particle;
            Spin = spin;
        }
    }
}
