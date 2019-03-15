using System;
using System.IO;

namespace Homework
{
    /// <summary>
    /// Интерфейс дерева разбора арифметического выражения
    /// </summary>
    public interface IParseTree
    {
        /// <summary>
        /// Считает значение полученного из файла "input.txt" арифметического выражения
        /// </summary>
        /// <returns>Значение выражения</returns>
        int Calculate();
    }
}
