using System;

namespace Exceptions
{
    /// <summary>
    /// Исключение, которое вызывается, когда игрок берёт кости (победит в игре)
    /// </summary>
    [Serializable]
    public class GotBonesException : Exception
    {
        public GotBonesException() { }
        public GotBonesException(string message) : base(message){ }
        public GotBonesException(string message, Exception inner)
            : base(message, inner) { }
    }
}
