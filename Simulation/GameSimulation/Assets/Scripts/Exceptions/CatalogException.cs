using System;

namespace Assets.Scripts.Exceptions
{
    public class CatalogException : Exception
    {
        public CatalogException(string message)
            : base(message)
        {
        }
    }
}
