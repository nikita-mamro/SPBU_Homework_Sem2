using System;
using System.Collections.Generic;

namespace Homework
{
    public class HashTable : IHashTable
    {
        /// <summary>
        /// Слоты таблицы, то есть списки, в которых хранятся элементы таблицы
        /// </summary>
        private List<List> Buckets;

        public int Count { get; private set; }
        /// <summary>
        /// Количество неповторяющихся значений
        /// </summary>
        private int differentCount;

        /// <summary>
        /// Отвечает за выбор реализации хэш функции
        /// </summary>
        private IHashFunction HashImplementation;

        /// <summary>
        /// Конструктор хэш-таблицы с выбранной реализацией хэш-функции
        /// </summary>
        /// <param name="hashImplementation">Реализация хэш-функции</param>
        public HashTable(IHashFunction hashImplementation)
        {
            this.HashImplementation = hashImplementation;

            Buckets = new List<List>();

            const int DefaultSize = 10;

            for (var i = 0; i < DefaultSize; ++i)
            {
                Buckets.Add(new List());
            }
        }

        /// <summary>
        /// Увеличение количества слотов хэш-таблицы
        /// </summary>
        private void Expand()
        {
            var newBuckets = new List<List>();

            for (var i = 0; i < Buckets.Count * 2; ++i)
            {
                newBuckets.Add(new List());
            }

            foreach (var list in Buckets)
            {
                if (list.IsEmpty)
                {
                    continue;
                }

                var words = list.GetWords();

                foreach (var word in words)
                {
                    var hash = (int)(HashImplementation.HashFunction(word) % newBuckets.Count);
                    newBuckets[hash].Add(word);
                }
            }

            Buckets = newBuckets;
        }

        public void Add(string word)
        {
            if (LoadCoefficient > 1)
            {
                Expand();
            }

            var hash = (int)(HashImplementation.HashFunction(word) % Buckets.Count);

            if (Buckets[hash].IsEmpty)
            {
                Buckets[hash] = new List();
                ++differentCount;
            }
            else if (!Buckets[hash].Contains(word))
            {
                ++differentCount;
            }

            Buckets[hash].Add(word);
            ++Count;
        }

        public void Remove(string word)
        {
            if (!IsContained(word))
            {
                throw new ArgumentException("Слово не найдено в наборе!");
            }

            var hash = (int)(HashImplementation.HashFunction(word) % Buckets.Count);

            if (!Buckets[hash].Remove(word))
            {
                return;
            }

            --Count;

            if (!Buckets[hash].Contains(word))
            {
                --differentCount;
            }
        }

        public bool IsContained(string word)
        {
            var hash = (int)(HashImplementation.HashFunction(word) % Buckets.Count);
            return Buckets[hash].Contains(word);
        }

        /// <summary>
        /// Коэффициент заполненности хэш-таблицы 
        /// (отношение количества отличных друг от друга элементов к количеству слотов)
        /// </summary>
        private double LoadCoefficient
        {
            get { return (double)differentCount / (double)Buckets.Count; }
        }

        public void Clear()
        {
            foreach (var list in Buckets)
            {
                list.Clear();
            }

            Count = 0;
            differentCount = 0;
        }
    }
}
