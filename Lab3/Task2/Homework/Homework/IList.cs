using System;

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
