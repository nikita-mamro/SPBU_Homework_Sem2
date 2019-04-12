using System;

namespace Exceptions
{
    /// <summary>
    /// Исключение, которое выбрасывается при попытке вызова Dequeue() для пустой приоритетной очереди
    /// </summary>
    [Serializable]
    public class DequeueCallForEmptyPriorityQueueException : Exception
    {
        public DequeueCallForEmptyPriorityQueueException() { }
        public DequeueCallForEmptyPriorityQueueException(string message) : base(message) { }
        public DequeueCallForEmptyPriorityQueueException(string message, Exception inner)
            : base(message, inner) { }
    }
}
