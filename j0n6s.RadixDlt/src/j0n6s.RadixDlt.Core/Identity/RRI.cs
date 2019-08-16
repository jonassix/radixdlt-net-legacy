using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Identity
{
    public class RRI
    {
        public RadixAddress Address { get; }
        public string Name { get; }

        public RRI(RadixAddress address, string name)
        {
            Address = address;
            Name = name;
        }

        public override string ToString()
        {
            return $"/{Address.ToString()}/{Name}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is RRI)) {
                return false;
            }

            RRI rri = (RRI)obj;

            return Address.Equals(rri.Address) && rri.Name == Name;
        }

        public override int GetHashCode()
        {
            var hashCode = 389620771;
            hashCode = hashCode * -1521134295 + EqualityComparer<RadixAddress>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
