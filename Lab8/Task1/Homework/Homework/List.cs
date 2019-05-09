using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework
{
    /// <summary>
    /// Класс, реализующий список
    /// </summary>
    /// <typeparam name="T">Тип значения, хранимого в списке</typeparam>
    public class List<T> : IList<T>
    {
        /// <summary>
        /// Класс, реализующий элемент списка
        /// </summary>
        private class Node
        {
            /// <summary>
            /// Значение, которое хранит элемент списка
            /// </summary>
            public T Data { get; set; }

            /// <summary>
            /// Следующий за текущим элемент списка
            /// </summary>
            public Node Next { get; set; }

            /// <summary>
            /// Конструктор элемента списка
            /// </summary>
            /// <param name="data">Значение, которое положим в созданный элемент</param>
            public Node(T data)
            {
                Data = data;
                Next = null;
            }

            /// <summary>
            /// Конструктор элемента списка
            /// </summary>
            /// <param name="data">Значение, которое положим в созданный элемент</param>
            /// <param name="next">Следующий за созданным элемент</param>
            public Node(T data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        /// <summary>
        /// Голова списка
        /// </summary>
        private Node head;

        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Индикатор того, является ли список доступным только для чтения
        /// </summary>
        public bool IsReadOnly { get; private set; }

        /// <summary>
        /// Конструктор класса список по умолчанию (IsReadOnly - false)
        /// </summary>
        public List()
        {

        }

        /// <summary>
        /// Конструктор класса список с учётом модификатора доступа
        /// </summary>
        /// <param name="isReadOnly"></param>
        public List(T[] elements, bool isReadOnly)
        {
            foreach (var element in elements)
            {
                Add(element);
            }

            IsReadOnly = isReadOnly;
        }

        /// <summary>
        /// Проверяет, существует ли элемент с данным индексом в списке
        /// </summary>
        /// <param name="index">Проверяемый индекс</param>
        private bool IsIndexValid(int index)
        {
            return index >= 0 && index < Count;
        }

        /// <summary>
        /// Получает значение, которое хранит элемент по указанному индексу
        /// </summary>
        private T GetDataByIndex(int index)
        {
            if (!IsIndexValid(index))
            {
                throw new IndexOutOfRangeException();
            }

            var tmp = head;

            for (var i = 0; i < index; ++i)
            {
                tmp = tmp.Next;
            }

            return tmp.Data;
        }

        /// <summary>
        /// Меняет значение, которое хранит элемент по указанному индексу
        /// </summary>
        private void SetDataByIndex(int index, T data)
        {
            if (IsReadOnly)
            {
                throw new Exceptions.EditingReadOnlyListException();
            }

            if (!IsIndexValid(index))
            {
                throw new IndexOutOfRangeException();
            }

            var tmp = head;

            for (var i = 0; i < index; ++i)
            {
                tmp = tmp.Next;
            }

            tmp.Data = data;
        }

        /// <summary>
        /// Перегрузка оператора []
        /// </summary>
        public T this[int index]
        {
            get
                => GetDataByIndex(index);
            set
                => SetDataByIndex(index, value);
        }

        /// <summary>
        /// Получает индекс, по которому хранится переданное значение
        /// </summary>
        public int IndexOf(T item)
        {
            var tmp = head;
            var index = 0;

            while (tmp != null && Comparer<T>.Default.Compare(tmp.Data, item) != 0)
            {
                tmp = tmp.Next;
                ++index;
            }

            if (index > Count - 1)
            {
                throw new Exceptions.ItemNotInListException();
            }

            return index;
        }

        /// <summary>
        /// Добавляет элемент с заданным значением в список на заданную позицию
        /// </summary>
        public void Insert(int index, T value)
        {
            if (IsReadOnly)
            {
                throw new Exceptions.EditingReadOnlyListException();
            }

            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                head = new Node(value, head);
                ++Count;
                return;
            }

            var tmp = head;

            for (var i = 0; i < index - 1; ++i)
            {
                tmp = tmp.Next;
            }

            tmp.Next = new Node(value, tmp.Next);
            ++Count;
        }

        /// <summary>
        /// Удаляет элемент из списка по заданному индексу
        /// </summary>
        public void RemoveAt(int index)
        {
            if (Count == 0)
            {
                throw new Exceptions.DeletingFromEmptyListException();
            }

            if (IsReadOnly)
            {
                throw new Exceptions.EditingReadOnlyListException("Попытка удаления элемента из ReadOnly списка.");
            }

            if (!IsIndexValid(index))
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                head = head.Next;
                --Count;
                return;
            }

            var tmp = head;

            for (var i = 0; i < index - 1; ++i)
            {
                tmp = tmp.Next;
            }

            tmp.Next = tmp.Next.Next;
            --Count;
            return;
        }

        /// <summary>
        /// Добавляет в конец списка элемент с заданным значением
        /// </summary>
        public void Add(T value)
        {
            Insert(Count, value);
        }

        /// <summary>
        /// Чистит список
        /// </summary>
        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new Exceptions.EditingReadOnlyListException();
            }

            head = null;
            Count = 0;
        }

        /// <summary>
        /// Проверяет, содержится ли переданное значение с списке
        /// </summary>
        public bool Contains(T item)
        {
            var tmp = head;

            while (tmp != null)
            {
                if (Comparer<T>.Default.Compare(tmp.Data, item) == 0)
                {
                    return true;
                }

                tmp = tmp.Next;
            }

            return false;
        }

        /// <summary>
        /// Копирует все элементы списка в данный массив, начиная с данного индекса
        /// </summary>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayIndex < 0)
            {
                throw new IndexOutOfRangeException("Указанный индекс в массиве не может быть отрицательным.");
            }

            if (array.Rank > 1)
            {
                throw new ArgumentException("Попытка копирования в массив размерности > 1.");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("Недостаточно места в массиве.");
            }

            for (var i = 0; i < Count; ++i)
            {
                array[i + arrayIndex] = this[i];
            }
        }

        /// <summary>
        /// Удаляет элемент с данным значением из списка
        /// </summary>
        /// <returns>False, если такого элемента нет, иначе True</returns>
        public bool Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new Exceptions.EditingReadOnlyListException();
            }

            if (!Contains(item))
            {
                return false;
            }

            var index = IndexOf(item);

            if (index == 0)
            {
                head = head.Next;
                --Count;
                return true;
            }

            var tmp = head;

            for (var i = 0; i < index - 1; ++i)
            {
                tmp = tmp.Next;
            }

            tmp.Next = tmp.Next.Next;
            --Count;
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var tmp = head;

            while (tmp != null)
            {
                yield return tmp.Data;
                tmp = tmp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
