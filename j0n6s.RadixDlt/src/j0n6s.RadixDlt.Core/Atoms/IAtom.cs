using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Core
{
    public interface IAtom
    {
        IParticleGroup ParticleGroup { get; set; }
        ICollection<Signature> Signatures { get; set; }
        IDictionary<string,string> Metadata { get; set; }
        ITemporalProof TemporalProof { get; set; }
    }
}
