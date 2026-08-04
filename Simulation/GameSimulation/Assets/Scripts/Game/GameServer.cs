using System.Collections.Generic;

namespace Assets.Scripts.Game
{
    public class GameServer
    {
        private readonly List<GameSession> _sessions = new List<GameSession>();

        public IReadOnlyCollection<GameSession> Sessions
            => _sessions;


        public void AddSession(GameSession session)
        {
            _sessions.Add(session);
        }


        public void Update(float deltaTime)
        {
            foreach (var session in _sessions)
            {
                session.Tick(deltaTime);
            }
        }
    }
}
