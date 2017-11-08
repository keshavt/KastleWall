using System;

namespace KastleWall.Encryption
{
    public class InvalidHashOperationException : Exception
    {
        public InvalidHashOperationException()
        {
        }

        public InvalidHashOperationException(string message)
            : base(message)
        {
        }

        public InvalidHashOperationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}