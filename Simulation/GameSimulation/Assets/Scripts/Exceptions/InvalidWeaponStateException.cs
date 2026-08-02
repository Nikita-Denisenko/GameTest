namespace Assets.Scripts.Exceptions
{
    public class InvalidWeaponStateException : DomainSimulationException
    {
        public InvalidWeaponStateException(string message)
            : base(message)
        {
        }
    }
}
