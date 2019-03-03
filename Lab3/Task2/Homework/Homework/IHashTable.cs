using System;

namespace Homework
{
    /// <summary>
    /// Интерфейс хэш-таблицы
    /// </summary>
    public interface IHashTable
    {
        /// <summary>
        /// Добавление элемента типа string в таблицу
        /// </summary>
        /// <param name="word">Добавляемое значение</param>
        void Add(string word);
        /// <summary>
        /// Удаление элемента из таблицы
        /// </summary>
        /// <param name="word">Значение удаляемого элемента</param>
        void Remove(string word);
        /// <summary>
        /// Проверка значения на принадлежность таблице
        /// </summary>
        /// <param name="word">Проверяемое значение</param>
        /// <returns>True - содержится, False - не содержится</returns>
        bool IsContained(string word);
        /// <summary>
        /// Очистка таблицы
        /// </summary>
        void Clear();
        /// <summary>
        /// Суммарное количество элементов в таблцице (с учётом повторений)
        /// </summary>
        int Count { get; }
    }
}
