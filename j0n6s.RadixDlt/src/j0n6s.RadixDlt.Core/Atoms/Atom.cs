using j0n6s.RadixDlt.EllipticCurve;
using j0n6s.RadixDlt.Particles;
using j0n6s.RadixDlt.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Atoms
{
    /// <summary>
    ///     An atom is the fundamental atomic unit of storage on the ledger 
    ///     (similar to a block in a blockchain) and defines the actions 
    ///     that can be issued onto the ledger.
    /// </summary>
    public class Atom
    {
        public static string METADATA_TIMESTAMP_KEY = "timestamp";
	    public static string METADATA_POW_NONCE_KEY = "powNonce";
        public List<ParticleGroup<Particle>> ParticleGroups  { get; set; }
        public Dictionary<string,ECSignature> Signatures { get; set; }
        public Dictionary<string, string> MetaData { get; set; }
        public AID Id { get; set; }
        
    }

    


}
