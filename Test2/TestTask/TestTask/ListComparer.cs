using System;
using System.Collections.Generic;

namespace TestTask
{
    /// <summary>
    /// Сравнивалка, сравнивает списки по количеству элементов
    /// </summary>
    /// <typeparam name="T">Тип хранимого в списке значения</typeparam>
    public class ListComparer<T> : IComparer<List<T>>
    {
        public int Compare(List<T> x, List<T> y)
        {
            return x.Count.CompareTo(y.Count);
        }
    }
}
