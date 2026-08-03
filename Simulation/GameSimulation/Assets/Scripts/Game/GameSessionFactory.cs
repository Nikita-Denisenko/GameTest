using Assets.Scripts.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Game
{
    public class GameSessionFactory
    {
        public GameSession Create(
            Player player,
            IEnumerable<Wave> waves)
        {
            return new GameSession(
                player,
                waves.OrderBy(x => x.StartSecond).ToList());
        }
    }
}
