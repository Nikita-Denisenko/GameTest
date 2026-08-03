using Assets.Scripts.Entities;
using System.Collections.Generic;

namespace Assets.Scripts.Game
{
    public class GameSession
    {
        public Player Player { get; }

        private readonly List<Wave> _waves = new();
        public IReadOnlyCollection<Wave> Waves
            => _waves;

        public IReadOnlyCollection<Enemy> Enemies
            => _enemies;

        private readonly List<Enemy> _enemies =
            new List<Enemy>();

        public float CurrentTime { get; private set; }

        public bool IsPaused { get; private set; }

        public GameSession(
            Player player,
            IReadOnlyCollection<Wave> waves)
        {
            Player = player;
            _waves.AddRange(waves);
        }

        public void Tick(float deltaTime)
        {
            if (IsPaused)
                return;

            CurrentTime += deltaTime;
        }

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void RemoveEnemy(Enemy enemy)
        {
            _enemies.Remove(enemy);
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Resume()
        {
            IsPaused = false;
        }
    }
}