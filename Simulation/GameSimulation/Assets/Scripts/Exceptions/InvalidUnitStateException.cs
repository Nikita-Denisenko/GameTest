namespace Assets.Scripts.Exceptions
{
    public class InvalidUnitStateException : DomainSimulationException
    {
        public InvalidUnitStateException(string message)
            : base(message)
        {
        }
    }
}