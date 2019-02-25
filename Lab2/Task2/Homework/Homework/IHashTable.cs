using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class IHashTable
    {
        public void Add(int data);
        public void Remove(int data);
        public bool IsContained(int data);
        public int Size { get; }
    }
}
