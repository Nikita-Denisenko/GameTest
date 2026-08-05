using System;

namespace Assets.Scripts.Exceptions
{
    public class InvalidArenaStateException : Exception
    {
        public InvalidArenaStateException(
            string message) : base(message)
        {
        }
    }
}
