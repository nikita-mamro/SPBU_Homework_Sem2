using System;

namespace Homework
{
    public interface IHashTable
    {
        void Add(string word);
        void Remove(string word);
        bool IsContained(string word);
        void Clear();
        int Count { get; }
    }
}
