using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public class HashTable : IHashTable
    {
        private List<List> buckets;

        public HashTable()
        {
            buckets = new List<List>();
        }

        private long HashFunction(ref string word)
        {
            long sum = 0;

            foreach (var letter in word)
            {
                sum = sum * 19 + letter * 31;
            }

            return sum;
        }

        public void Add(ref string word)
        {
            int hash = (int)(HashFunction(ref word) % buckets.Count);
        }

        public void Remove(ref string word)
        {

        }

        public bool IsContained(ref string word)
        {

        }

        private int GetElementsCount()
        {
            int result = 0;

            foreach (var list in buckets)
            {
                if (!list.isEmpty)
                {
                    result += list.Size;
                }
            }

            return result;
        }

        public int Count
        {
            get { return GetElementsCount(); }
        }

        public void Clear()
        {
            foreach (var list in buckets)
            {
                list.Clear();
            }
        }
    }
}
