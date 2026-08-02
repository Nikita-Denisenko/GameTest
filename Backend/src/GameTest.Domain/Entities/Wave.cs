using GameTest.Domain.Exceptions;
using GameTest.Domain.ValueObjects;

namespace GameTest.Domain.Entities
{
    public class Wave
    {
        public int Id { get; private set; }
        public int Number { get; private set; }
        public int StartSecond { get; private set; }
        public int EndSecond { get; private set; }

        private readonly List<WaveEnemy> _enemies = [];
        public IReadOnlyCollection<WaveEnemy> Enemies => _enemies;

        private Wave() { }

        public Wave(
            int number, 
            int startSecond,
            int endSecond,
            IEnumerable<WaveEnemy> enemies)
        {
            if (number <= 0)
                throw new DomainException("Wave number must be greater than zero.");

            if (startSecond < 0 || endSecond < 0)
                throw new DomainException("Start and End seconds must be non-negative.");

            if (startSecond >= endSecond)
                throw new DomainException("Start second must be less than End second.");

            if (enemies == null || !enemies.Any())
                throw new DomainException("Enemies cannot be empty.");
            
            Number = number;
            StartSecond = startSecond;
            EndSecond = endSecond;
            _enemies.AddRange(enemies);
        }
    }
}
