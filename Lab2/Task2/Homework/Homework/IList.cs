using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public interface IList
    {
        void Add(string data);
        void Remove(string word);
        bool Contains(string word);
        int Size { get; }
        bool isEmpty { get; }
        void Clear();
    }
}
