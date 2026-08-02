namespace Assets.Scripts.Exceptions
{
    public class InvalidValueObjectException : DomainSimulationException
    {
        public InvalidValueObjectException(string message)
            : base(message)
        {
        }
    }
}
