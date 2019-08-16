using j0n6s.RadixDlt.Primitives;
using System;

namespace j0n6s.RadixDlt.Atoms
{
    /// <summary>
    ///     An Atom ID, made up of 192 bits of truncated hash and 64 bits of a selected shard.    
    ///     The Atom ID is used so that Atoms can be located using just their hid.
    /// </summary>
    public class AID
    {
        public static int HASH_BYTES_SIZE = 24;
        static int SHARD_BYTES_SIZE = 8;

        private readonly byte[] _bytes = new byte[HASH_BYTES_SIZE + SHARD_BYTES_SIZE];

        public long Shard => Longs.FromByteArray(_bytes, HASH_BYTES_SIZE);

        public AID(byte[] bytes)
        {
            if (bytes.Length != HASH_BYTES_SIZE + SHARD_BYTES_SIZE)
                throw new ArgumentException($"{nameof(bytes)} should be length {HASH_BYTES_SIZE + SHARD_BYTES_SIZE} but was {bytes.Length}");
            Array.Copy(bytes, _bytes, _bytes.Length);
        }

        public AID(byte[] hashBytes, byte[] shardBytes)
        {
            if (hashBytes.Length != HASH_BYTES_SIZE)
                throw new ArgumentException($"{nameof(hashBytes)} should be length {HASH_BYTES_SIZE} but was {hashBytes.Length}");
            if (shardBytes.Length != SHARD_BYTES_SIZE)
                throw new ArgumentException($"{nameof(shardBytes)} should be length {SHARD_BYTES_SIZE} but was {shardBytes.Length}");

            _bytes = ArrayHelpers.ConcatArrays(hashBytes, shardBytes);
        }

        public AID(string hexBytes)
            : this(Bytes.FromHexString(hexBytes))
        {
        }

        public override string ToString()
        {
            return Bytes.ToHexString(_bytes);            
        }


    }
}
