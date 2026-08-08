using System;

namespace Assets.Scripts.Exceptions
{
    public class CatalogException : DomainSimulationException
    {
        public CatalogException(string message)
            : base(message)
        {
        }
    }
}
