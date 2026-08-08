using System;

namespace Assets.Scripts.Exceptions
{
    public class InvalidGameSessionStateException : DomainSimulationException
    {
        public InvalidGameSessionStateException(string message)
            : base(message)
        {
        }
    }
}
