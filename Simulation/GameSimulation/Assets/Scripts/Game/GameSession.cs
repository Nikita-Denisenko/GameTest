using Assets.Scripts.Entities;
using Assets.Scripts.GameData.Runs;
using System.Collections.Generic;

namespace Assets.Scripts.Game
{
    public class GameSession
    {
        public RunPreparationData Preparation { get; }

        public Player Player { get; }


        private readonly List<Wave> _waves = new();

        public IReadOnlyCollection<Wave> Waves
            => _waves;


        private readonly List<Enemy> _enemies = new();

        public IReadOnlyCollection<Enemy> Enemies
            => _enemies;


        public float CurrentTime { get; private set; }

        public bool IsPaused { get; private set; }


        public GameSession(
            RunPreparationData preparation,
            Player player,
            IEnumerable<Wave> waves)
        {
            Preparation = preparation;
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
