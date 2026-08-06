namespace Assets.Scripts.Game
{
    public class GameSimulation
    {
        public GameSession Session { get; }


        public GameSimulation(
            GameSession session)
        {
            Session = session;
        }


        public void Tick(
            float deltaTime)
        {
            Session.Tick(deltaTime);
        }
    }
}
