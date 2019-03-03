using System;

namespace Homework
{
    /// <summary>
    /// Интерфейс односвязного списка
    /// </summary>
    public interface IList
    {
        /// <summary>
        /// Добавление элемента в конец списка
        /// </summary>
        /// <param name="data">Добавляемый элемент, тип string</param>
        void Add(string data);
        /// <summary>
        /// Удаление данного элемента из списка по значению
        /// </summary>
        /// <param name="word">Значение типа string удаляемого элемента</param>
        /// <returns>Возвращает true, если элемент успешно удалён</returns>
        bool Remove(string word);
        /// <summary>
        /// Проверка, содержится ли элемент в списке
        /// </summary>
        /// <param name="word">Значение типа string проверяемого элемента</param>
        /// <returns>Возвращает true, если элемент содержится, false - если нет</returns>
        bool Contains(string word);
        /// <summary>
        /// Размер списка (количество уникальных по значению элементов)
        /// </summary>
        int Size { get; }
        /// <summary>
        /// Индикатор отутствия элементов в списке
        /// </summary>
        bool IsEmpty { get; }
        /// <summary>
        /// Очистка списка
        /// </summary>
        void Clear();
    }
}
