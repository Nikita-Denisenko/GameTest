using System;

namespace Assets.Scripts.Exceptions
{
    public class InvalidArenaStateException : DomainSimulationException
    {
        public InvalidArenaStateException(
            string message) : base(message)
        {
        }
    }
}
