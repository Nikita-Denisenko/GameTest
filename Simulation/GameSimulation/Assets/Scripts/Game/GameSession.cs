using Assets.Scripts.Entities;
using Assets.Scripts.Exceptions;
using Assets.Scripts.GameData.Runs;
using System.Collections.Generic;

namespace Assets.Scripts.Game
{
    public class GameSession
    {
        public Arena Arena {  get; }
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
            Arena arena,
            RunPreparationData preparation,
            Player player,
            IEnumerable<Wave> waves)
        {
            if (arena == null)
                throw new InvalidGameSessionStateException(
                    "Arena cannot be null.");

            if (preparation == null)
                throw new InvalidGameSessionStateException(
                    "Preparation cannot be null.");

            if (player == null)
                throw new InvalidGameSessionStateException(
                    "Player cannot be null.");

            if (waves == null)
                throw new InvalidGameSessionStateException(
                    "Waves cannot be null.");

            Arena = arena;

            Preparation = preparation;
            Player = player;

            _waves.AddRange(waves);

            CurrentTime = 0;
            IsPaused = false;
        }


        public void Tick(
            float deltaTime)
        {
            if (IsPaused)
                return;

            CurrentTime += deltaTime;
        }


        public void AddEnemy(
            Enemy enemy)
        {
            if (enemy == null)
                throw new InvalidGameSessionStateException(
                    "Enemy cannot be null.");

            _enemies.Add(enemy);
        }


        public void RemoveEnemy(
            Enemy enemy)
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
