namespace Assets.Scripts.Exceptions
{
    public class InvalidEnemyStateException : DomainSimulationException
    {
        public InvalidEnemyStateException(string message)
            : base(message)
        {
        }
    }
}