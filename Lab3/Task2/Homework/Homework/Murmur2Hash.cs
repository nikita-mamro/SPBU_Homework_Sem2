using System;

namespace Homework
{
    /// <summary>
    /// Класс, реализующий алгоритм Murmur2 получения хэша
    /// </summary>
    public class Murmur2Hash : IHashFunction
    {
        long IHashFunction.HashFunction(string word)
        {
            const int m = 0x5bd1e995;
            const uint seed = 0;
            const int r = 24;
            var length = word.Length;

            var hash = seed ^ length;

            var data = word;
            int k;

            while (length >= 4)
            {
                k = data[0];
                k |= data[1] << 8;
                k |= data[2] << 16;
                k |= data[3] << 24;

                k *= m;
                k ^= k >> r;
                k *= m;

                hash *= m;
                hash ^= k;

                data += 4;
                length -= 4;
            }

            switch (length)
            {
                case 3:
                    hash ^= data[2] << 16;
                    break;
                case 2:
                    hash ^= data[1] << 8;
                    break;
                case 1:
                    hash ^= data[0];
                    hash *= m;
                    break;
            };

            hash ^= hash >> 13;
            hash *= m;
            hash ^= hash >> 15;

            return hash;
        }
    }
}
