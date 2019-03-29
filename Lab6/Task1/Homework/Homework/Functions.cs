using System;
using System.Collections.Generic;

namespace Homework
{
    /// <summary>
    /// Класс, реализующий функции Map(), Filter() и Fold()
    /// </summary>
    public static class Functions
    {
        /// <summary>
        /// Возвращает преобразованный список, применяя заданную функцию к каждому элементу
        /// </summary>
        /// <typeparam name="T">Тип элементов переданного списка</typeparam>
        /// <typeparam name="TRes">Тип преобразованных элементов</typeparam>
        /// <param name="list">Передаваемый список</param>
        /// <param name="function">Функция, применяемая к каждому элемнту переданного списка</param>
        /// <returns>Преобразованный список</returns>
        public static List<TRes> Map<T, TRes>(List<T> list, Func<T, TRes> function)
        {
            List<TRes> res = new List<TRes>();

            foreach (var element in list)
            {
                res.Add(function(element));
            }

            return res;
        }

        /// <summary>
        /// Возвращает список элементов переданного списка, удовлетворяющих условию
        /// </summary>
        /// <typeparam name="T">Тип элементов переданного списка</typeparam>
        /// <param name="list">Передаваемый список</param>
        /// <param name="condition">Функция-условие</param>
        /// <returns>Список элементов, удовлетворяющих условию</returns>
        public static List<T> Filter<T>(List<T> list, Func<T, bool> condition)
        {
            List<T> res = new List<T>();

            foreach (var element in list)
            {
                if (condition(element))
                {
                    res.Add(element);
                }
            }

            return res;
        }

        /// <summary>
        /// Возвращает накопленное после обхода списка значение
        /// </summary>
        /// <typeparam name="T">Тип элементов переданного списка</typeparam>
        /// <typeparam name="TRes">Тип полученного значения</typeparam>
        /// <param name="list">Передаваемый список</param>
        /// <param name="initial">Начальное накопленное значение</param>
        /// <param name="function">Выражает следующее накопленнное значение через текущее и элемент списка</param>
        /// <returns>Накопленное значение</returns>
        public static TRes Fold<T, TRes>(List<T> list, TRes initial, Func<TRes, T, TRes> function)
        {
            TRes acc = initial;

            foreach (var element in list)
            {
                acc = function(acc, element);
            }

            return acc;
        }
    }
}
