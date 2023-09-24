using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    internal class Entries<TKey, TValue>
    {
        public TKey key;
        public TValue value;
        public int next;
        public uint hashCode;
    }
}
