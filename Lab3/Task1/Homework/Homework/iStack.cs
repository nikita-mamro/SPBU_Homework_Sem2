using System;

namespace Homework
{
    /// <summary>
    /// Интерфейс стека
    /// </summary>
    public interface IStack
    {
        /// <summary>
        /// Добавляет элемент в стек
        /// </summary>
        /// <param name="data">Добавляемое значение</param>
        void Push(int data);

        /// <summary>
        /// Удаляет элемент с вершины стека
        /// </summary>
        /// <returns>Значение удалённого элемента</returns>
        int Pop();

        /// <summary>
        /// Возвращает значение элемента на вершине стека
        /// </summary>
        /// <returns>Значение элемента на вершине стека</returns>
        int Peek();

        /// <summary>
        /// Проверяет, пустой ли стек
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Удаляет все элементы стека
        /// </summary>
        void Clear();

        /// <summary>
        /// Количество элементов в стеке
        /// </summary>
        int Count { get; }
    }
}
