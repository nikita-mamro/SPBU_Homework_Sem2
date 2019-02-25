using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public class HashTable : IHashTable
    {
        private List<List> buckets;

        public int Count { get; private set; } // total number of elements
        private int DifferentCount { get; set; } // number of elements excluding repeating

        public HashTable()
        {
            buckets = new List<List>();

            const int defaultSize = 10;

            for (var i = 0; i < defaultSize; ++i)
            {
                buckets.Add(new List());
            }
        }

        private long HashFunction(string word)
        {
            long sum = 0;

            foreach (var letter in word)
            {
                sum = sum * 19 + letter * 31;
            }

            return sum;
        }

        private void Expand()
        {
            var newBuckets = new List<List>();

            for (var i = 0; i < buckets.Count * 2; ++i)
            {
                newBuckets.Add(new List());
            }

            foreach (var list in buckets)
            {
                if (list.isEmpty)
                {
                    continue;
                }

                var words = list.GetWords();

                foreach (var word in words)
                {
                    var hash = (int)(HashFunction(word) % newBuckets.Count);
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

            var hash = (int)(HashFunction(word) % buckets.Count);

            if (buckets[hash].isEmpty)
            {
                buckets[hash] = new List();
                ++DifferentCount;
            }
            else if (!buckets[hash].Contains(word))
            {
                ++DifferentCount;
            }

            buckets[hash].Add(word);
            ++Count;
        }

        public void Remove(string word)
        {
            if (!IsContained(word))
            {
                Console.WriteLine("Слово не найдено в наборе!");
            }

            var hash = (int)(HashFunction(word) % buckets.Count);

            buckets[hash].Remove(word);

            --Count;

            if (!buckets[hash].Contains(word))
            {
                --DifferentCount;
            }
        }

        public bool IsContained(string word)
        {
            var hash = (int)(HashFunction(word) % buckets.Count);
            return buckets[hash].Contains(word);
        }

        private double LoadCoefficient
        {
            get { return (double)DifferentCount / (double)buckets.Count; }
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
