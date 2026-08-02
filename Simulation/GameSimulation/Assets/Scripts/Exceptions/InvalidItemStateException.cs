namespace Assets.Scripts.Exceptions
{
    public class InvalidItemStateException : DomainSimulationException
    {
        public InvalidItemStateException(string message)
            : base(message)
        {
        }
    }
}
