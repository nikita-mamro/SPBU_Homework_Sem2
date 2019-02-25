using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public interface IList
    {
        void Add(ref string data);
        bool Remove(int position);
        int Size { get; }
        bool isEmpty { get; }
        void Print();
        void Clear();
    }
}
