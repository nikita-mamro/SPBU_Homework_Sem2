using System;
using System.Collections.Generic;

namespace TestTask
{
    public class ListComparer<T> : IComparer<List<T>>
    {
        public int Compare(List<T> x, List<T> y)
        {
            return x.Count.CompareTo(y.Count);
        }
    }
}
