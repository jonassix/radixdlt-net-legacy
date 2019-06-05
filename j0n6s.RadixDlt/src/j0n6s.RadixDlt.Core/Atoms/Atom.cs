using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Core
{
    public class Atom : IAtom
    {
        public IParticleGroup ParticleGroup { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICollection<Signature> Signatures { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDictionary<string, string> Metadata { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ITemporalProof TemporalProof { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
