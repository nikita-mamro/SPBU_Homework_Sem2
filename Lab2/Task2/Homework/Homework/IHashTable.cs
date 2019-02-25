using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public interface IHashTable
    {
        public void Add(ref string word);
        public void Remove(ref string word);
        public bool IsContained(ref string word);
        public void Clear();
        public int Count { get; }
    }
}
