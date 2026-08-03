using Assets.Scripts.Exceptions;

namespace Assets.Scripts.ValueObjects
{
    public class WaveEnemy
    {
        public int EnemyId { get; private set; }
        public EnemyQuantityRange QuantityRange { get; private set; } = null!;
        public int SpawnInterval { get; private set; }

        public WaveEnemy(
            int enemyId,
            EnemyQuantityRange quantityRange,
            int spawnInterval)
        {
            if (enemyId <= 0)
                throw new InvalidEnemyStateException(
                    "EnemyId must be greater than zero.");

            if (quantityRange == null)
                throw new InvalidValueObjectException("QuantityRange cannot be null.");

            if (spawnInterval <= 0)
                throw new InvalidValueObjectException("SpawnInterval must be positive.");

            EnemyId = enemyId;
            QuantityRange = quantityRange;
            SpawnInterval = spawnInterval;
        }
    }
}
