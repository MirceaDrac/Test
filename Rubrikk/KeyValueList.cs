using System;
using System.Collections.Generic;

namespace Part1
{
    internal class KeyValueList<T1, T2>: List<KeyValuePair<T1,T2>>
    {
        internal void Add(T1 key, T2 value)
        {
            Add(new KeyValuePair<T1,T2>(key, value));
        }
    }
}