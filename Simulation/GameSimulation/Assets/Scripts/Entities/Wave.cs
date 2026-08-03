using Assets.Scripts.Exceptions;
using Assets.Scripts.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Entities
{
    public class Wave
    {
        public int Id { get; private set; }
        public int Number { get; private set; }
        public int StartSecond { get; private set; }
        public int EndSecond { get; private set; }

        private readonly List<WaveEnemy> _enemies 
            = new List<WaveEnemy>();
        public IReadOnlyCollection<WaveEnemy> Enemies 
            => _enemies;

        public Wave(int id, int number, int startSecond, int endSecond, IEnumerable<WaveEnemy> enemies)
        {
            if (id <= 0)
                throw new InvalidWaveStateException("Wave ID must be greater than zero.");

            if (number <= 0)
                throw new InvalidWaveStateException("Wave number must be greater than zero.");

            if (startSecond < 0 || endSecond < 0)
                throw new InvalidWaveStateException("Start and end seconds must be non-negative.");

            if (startSecond >= endSecond)
                throw new InvalidWaveStateException("Start second must be less than end second.");

            if (enemies == null || !enemies.Any())
                throw new InvalidWaveStateException("Wave must contain at least one enemy.");

            Id = id;
            Number = number;
            StartSecond = startSecond;
            EndSecond = endSecond;
            _enemies.AddRange(enemies);
        }
    }
}
