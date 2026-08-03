using Assets.Scripts.Exceptions;

namespace Assets.Scripts.StaticData
{
    public class WaveEnemyData
    {
        public int EnemyId { get; }
        public EnemyQuantityRangeData QuantityRange { get; }
        public int SpawnInterval { get; }

        public WaveEnemyData(
            int enemyId,
            EnemyQuantityRangeData quantityRange,
            int spawnInterval)
        {
            if (enemyId <= 0)
                throw new InvalidWaveStateException("Enemy id must be greater than zero.");

            if (spawnInterval <= 0)
                throw new InvalidWaveStateException("Spawn interval must be greater than zero.");

            EnemyId = enemyId;
            QuantityRange = quantityRange ?? throw new InvalidWaveStateException("Quantity range cannot be null.");
            SpawnInterval = spawnInterval;
        }
    }
}
