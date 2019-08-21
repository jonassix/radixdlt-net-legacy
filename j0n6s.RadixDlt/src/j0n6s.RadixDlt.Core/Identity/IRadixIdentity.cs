using j0n6s.RadixDlt.Atoms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace j0n6s.RadixDlt.Identity
{
    public interface IRadixIdentity
    {
        Task<Atom> Sign(Atom atom);
        //Task<UnencryptedData> Decrypt;
    }
}
