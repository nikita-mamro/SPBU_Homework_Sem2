using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public class HashTable
    {
        //private List<List> buckets;
        private List[] buckets;

        public int Count { get; private set; } // total number of elements
        private int differentCount;// number of elements excluding repeating

        public HashTable()
        {
            const int DefaultSize = 10;

            buckets = new List[DefaultSize];

            for (var i = 0; i < DefaultSize; ++i)
            {
                buckets[i] = new List();
            }
        }

        private long HashFunction(string word)
        {
            long sum = 0;

            foreach (var letter in word)
            {
                sum = sum * 19 + letter * 31;
            }

            return Math.Abs(sum);
        }

        private void Expand()
        {
            int newSize = buckets.Length * 2;

            var newBuckets = new List[newSize];

            for (var i = 0; i < newSize; ++i)
            {
                newBuckets[i] = new List();
            }

            foreach (var list in buckets)
            {
                if (list.IsEmpty)
                {
                    continue;
                }

                var words = list.GetWords();

                foreach (var word in words)
                {
                    var hash = (int)(HashFunction(word) % newBuckets.Length);
                    newBuckets[hash].Add(word);
                }
            }

            buckets = newBuckets;
        }

        public void Add(string word)
        {
            if (LoadCoefficient > 1)
            {
                Expand();
            }

            var hash = (int)(HashFunction(word) % buckets.Length);

            if (buckets[hash].IsEmpty)
            {
                buckets[hash] = new List();
                ++differentCount;
            }
            else if (!buckets[hash].Contains(word))
            {
                ++differentCount;
            }

            buckets[hash].Add(word);
            ++Count;
        }

        public bool Remove(string word)
        {
            if (!IsContained(word))
            {
                return false;
            }

            var hash = (int)(HashFunction(word) % buckets.Length);

            if (!buckets[hash].Remove(word))
            {
                return true;
            }

            --Count;

            if (!buckets[hash].Contains(word))
            {
                --differentCount;
            }

            return true;
        }

        public bool IsContained(string word)
        {
            var hash = (int)(HashFunction(word) % buckets.Length);
            return buckets[hash].Contains(word);
        }

        private double LoadCoefficient
        {
            get { return (double)differentCount / (double)buckets.Length; }
        }

        public void Clear()
        {
            foreach (var list in buckets)
            {
                list.Clear();
            }
            Count = 0;
            differentCount = 0;
        }
    }
}
