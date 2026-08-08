namespace Assets.Scripts.Exceptions
{
    public class InvalidWaveStateException : DomainSimulationException
    {
        public InvalidWaveStateException(string message)
            : base(message)
        {
        }
    }
}
