using System;

namespace Homework
{
    /// <summary>
    /// Интерфейс хэш-функции для хэш-таблицы
    /// </summary>
    public interface IHashFunction
    {
        /// <summary>
        /// Функция, считающая хэш для данного слова
        /// </summary>
        /// <param name="word">Слово, для которого ищем хэш</param>
        /// <returns>Хэш</returns>
        long HashFunction(string word);
    }
}
