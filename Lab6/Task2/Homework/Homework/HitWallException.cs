using System;

namespace Exceptions
{
    /// <summary>
    /// Исключение, которое вызывается, когда игрок врезается в стену
    /// </summary>
    [Serializable]
    public class HitWallException : Exception
    {
        public HitWallException() { }
        public HitWallException(string message) : base(message) { }
        public HitWallException(string message, Exception inner) 
            : base(message, inner) { }
    }
}
