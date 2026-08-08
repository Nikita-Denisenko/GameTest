namespace Assets.Scripts.Exceptions
{
    public class InvalidPlayerStateException : DomainSimulationException
    {
        public InvalidPlayerStateException(string message)
            : base(message)
        {
        }
    }
}