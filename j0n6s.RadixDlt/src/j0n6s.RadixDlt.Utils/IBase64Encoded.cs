using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt
{
    public interface IBase64Encoded
    {
        //string GetBase64string();
        string Base64 { get; }

        byte[] Base64Array { get; }
    }
}
