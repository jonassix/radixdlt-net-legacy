using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Atoms
{
    public enum AtomStatus
    {
        DOES_NOT_EXIST,
        EVICTED_INVALID_ATOM,
        EVICTED_FAILED_CM_VERIFICATION,
        EVICTED_CONFLICT_LOSER,
        PENDING_CM_VERIFICATION,
        PENDING_DEPENDENCY_VERIFICATION,
        MISSING_DEPENDENCY,
        CONFLICT_LOSER,
        STORED
    }
}
