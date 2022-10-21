using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Extensions
{
    public static class HashSetExtensions
    {
        public static IList<T> ToIList<T>(this HashSet<T> hashSet)
        {
            return hashSet.ToList();
        }
    }
}
