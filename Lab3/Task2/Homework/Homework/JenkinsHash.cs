using System;

namespace Homework
{
    /// <summary>
    /// Класс, реализующий алгоритм Дженксинса получения хеша
    /// </summary>
    public class JenkinsHash : IHashFunction
    {
        long IHashFunction.HashFunction(string word)
        {
            long hash = 0;

            foreach (var letter in word)
            {
                hash += letter;
                hash += (hash << 10);
                hash ^= (hash >> 6);
            }

            hash += (hash << 3);
            hash ^= (hash >> 11);
            hash += (hash << 15);

            return Math.Abs(hash);
        }
    }
}
