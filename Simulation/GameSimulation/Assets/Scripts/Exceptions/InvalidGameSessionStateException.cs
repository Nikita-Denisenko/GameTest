using System;

namespace Assets.Scripts.Exceptions
{
    public class InvalidGameSessionStateException : Exception
    {
        public InvalidGameSessionStateException(string message)
            : base(message)
        {
        }
    }
}
