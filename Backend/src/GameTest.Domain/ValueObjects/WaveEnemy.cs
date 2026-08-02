using GameTest.Domain.Exceptions;

namespace GameTest.Domain.ValueObjects
{
    public record WaveEnemy
    {
        public int EnemyId { get; init; }
        public EnemyQuantityRange QuantityRange { get; init; } = null!;
        public int SpawnInterval { get; init; }

        private WaveEnemy()
        {
        }

        public WaveEnemy(
            int enemyId, 
            EnemyQuantityRange quantityRange, 
            int spawnInterval)
        {
            if (enemyId <= 0)
                throw new DomainException(
                    "EnemyId must be greater than zero.");

            if (quantityRange == null)
                throw new DomainException("QuantityRange cannot be null.");

            if (spawnInterval <= 0)
                throw new DomainException("SpawnInterval must be positive.");

            EnemyId = enemyId;
            QuantityRange = quantityRange;
            SpawnInterval = spawnInterval;
        }
    }
}
