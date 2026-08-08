namespace Assets.Scripts.Exceptions.Game
{
    public class NoMoreWavesException : GameException
    {
        public NoMoreWavesException(string message) 
            : base(message)
        {
        }
    }
}
