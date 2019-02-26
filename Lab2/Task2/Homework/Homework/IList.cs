using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public interface IList
    {
        void Add(string data);
        bool Remove(string word);
        bool Contains(string word);
        int Size { get; }
        bool IsEmpty { get; }
        void Clear();
    }
}
