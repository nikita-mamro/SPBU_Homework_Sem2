using System;
using System.Collections.Generic;

namespace Homework
{
    /// <summary>
    /// Класс, реализующий хэш-таблицу
    /// </summary>
    public class HashTable : IHashTable
    {
        /// <summary>
        /// Слоты таблицы, то есть списки, в которых хранятся элементы таблицы
        /// </summary>
        private List<IList> buckets;

        public int Count { get; private set; }

        /// <summary>
        /// Количество неповторяющихся значений
        /// </summary>
        private int differentCount;

        /// <summary>
        /// Отвечает за выбор реализации хэш функции
        /// </summary>
        private IHashFunction hashImplementation;

        /// <summary>
        /// Конструктор хэш-таблицы с выбранной реализацией хэш-функции
        /// </summary>
        /// <param name="hashImplementation">Реализация хэш-функции</param>
        public HashTable(IHashFunction hashImplementation)
        {
            this.hashImplementation = hashImplementation;

            buckets = new List<IList>();

            const int DefaultSize = 10;

            for (var i = 0; i < DefaultSize; ++i)
            {
                buckets.Add(new List());
            }
        }

        /// <summary>
        /// Увеличение количества слотов хэш-таблицы
        /// </summary>
        private void Expand()
        {
            var newBuckets = new List<IList>();

            for (var i = 0; i < buckets.Count * 2; ++i)
            {
                newBuckets.Add(new List());
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
                    var hash = Math.Abs((int)(hashImplementation.HashFunction(word) % newBuckets.Count));
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

            var hash = Math.Abs((int)(hashImplementation.HashFunction(word) % buckets.Count));

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

        public void Remove(string word)
        {
            if (!IsContained(word))
            {
                throw new ArgumentException("Слово не найдено в наборе!");
            }

            var hash = Math.Abs((int)(hashImplementation.HashFunction(word) % buckets.Count));

            if (!buckets[hash].Remove(word))
            {
                return;
            }

            --Count;

            if (!buckets[hash].Contains(word))
            {
                --differentCount;
            }
        }

        public bool IsContained(string word)
        {
            var hash = Math.Abs((int)(hashImplementation.HashFunction(word) % buckets.Count));
            return buckets[hash].Contains(word);
        }

        /// <summary>
        /// Коэффициент заполненности хэш-таблицы 
        /// (отношение количества отличных друг от друга элементов к количеству слотов)
        /// </summary>
        private double LoadCoefficient
            => (double)differentCount / (double)buckets.Count;

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
