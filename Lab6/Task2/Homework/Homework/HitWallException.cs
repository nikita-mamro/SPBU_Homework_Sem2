using System;

namespace Exceptions
{
    [Serializable]
    public class HitWallException : Exception
    {
        public HitWallException() { }
        public HitWallException(string message) : base(message) { }
        public HitWallException(string message, Exception inner) 
            : base(message, inner) { }
    }
}
