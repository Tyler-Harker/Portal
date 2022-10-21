using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Privileges
{
    public struct Privilege
    {
        public Type Type { get; private set; }
        public int Value { get; private set; }
        public Privilege(Type type, int value)
        {
            Type = type;
            Value = value;
        }
    }
}
