using System;

namespace Exceptions
{
    /// <summary>
    /// Исключение, которое вызывается, если игрок выходит за пределы экрана
    /// </summary>
    [Serializable]
    public class GoingOutOfScreenException : Exception
    {
        public GoingOutOfScreenException() { }
        public GoingOutOfScreenException(string message) : base(message) { }
        public GoingOutOfScreenException(string message, Exception inner)
            : base(message, inner) { }
    }
}
