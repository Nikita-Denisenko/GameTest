using System;

namespace Assets.Scripts.Exceptions
{
    public abstract class DomainSimulationException : Exception
    {
        protected DomainSimulationException(string message)
            : base(message)
        {
        }
    }
}
