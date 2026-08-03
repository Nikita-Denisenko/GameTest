using Assets.Scripts.Entities;
using System.Collections.Generic;

namespace Assets.Scripts.Core
{
    public class SimulationContext
    {
        private readonly List<Enemy> _enemies =
            new List<Enemy>();

        public IReadOnlyCollection<Enemy> Enemies
            => _enemies;

        public Player Player { get; }

        public SimulationContext(Player player)
        {
            Player = player;
        }

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void RemoveEnemy(Enemy enemy)
        {
            _enemies.Remove(enemy);
        }
    }
}
