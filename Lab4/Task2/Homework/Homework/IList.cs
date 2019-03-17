using System;

namespace Lists
{
    /// <summary>
    /// Интерфейс связного списка
    /// </summary>
    public interface IList
    {
        /// <summary>
        /// Добавление в список на заданную позицию
        /// </summary>
        /// <param name="data">Добавляемое значение</param>
        /// <param name="position">Позиция</param>
        void Add(int data, int position);
        /// <summary>
        /// Удаление данного элемента из списка
        /// </summary>
        /// <param name="data">Удаляемое значение</param>
        void Remove(int data);
        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Проверяет, пуст ли список
        /// </summary>
        /// <returns>True, если в списке нет элементов, иначе false</returns>
        bool IsEmpty();
        /// <summary>
        /// Проверяет, существует ли в списке элемент с заданным значением
        /// </summary>
        /// <param name="data">Искомое значение</param>
        /// <returns>True, если значение содержится в списке, иначе false</returns>
        bool Exists(int data);
        /// <summary>
        /// Распечатать лист
        /// </summary>
        void Print();
    }
}
