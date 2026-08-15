namespace Assets.Scripts.Exceptions.Domain
{
    public class InvalidCatStateException : DomainSimulationException
    {
        public InvalidCatStateException(string message) : base(message)
        {
        }
    }
}
