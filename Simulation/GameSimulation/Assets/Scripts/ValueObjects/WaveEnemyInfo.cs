using Assets.Scripts.Exceptions;

namespace Assets.Scripts.ValueObjects
{
    public class WaveEnemyInfo
    {
        public int EnemyId { get; }
        public int SpawnInterval { get; }
        public float SecondsUntilSpawn { get; private set; }
        public int Quantity { get; }
        public int SpawnedCount { get; private set; }

        public WaveEnemyInfo(
            int enemyId,
            int spawnInterval,
            float secondsUntilSpawn,
            int quantity)
        {
            if (enemyId <= 0)
                throw new InvalidValueObjectException(
                    "Enemy ID must be greater than zero.");

            if (spawnInterval <= 0)
                throw new InvalidValueObjectException(
                    "Spawn interval must be greater than zero.");

            if (secondsUntilSpawn < 0)
                throw new InvalidValueObjectException(
                    "Seconds until spawn must be non-negative.");

            if (quantity <= 0)
                throw new InvalidValueObjectException(
                    "Quantity must be greater than zero.");

            EnemyId = enemyId;
            SpawnInterval = spawnInterval;
            SecondsUntilSpawn = secondsUntilSpawn;
            Quantity = quantity;
            SpawnedCount = 0;
        }

        public void AdvanceTime(
            float deltaTime)
        {
            if (deltaTime <= 0)
                throw new InvalidValueObjectException(
                    "Delta time must be greater than zero.");

            SecondsUntilSpawn -= deltaTime;
        }

        public void ResetTimer()
        {
            SecondsUntilSpawn = SpawnInterval;
        }

        public void AddCount()
        {
            if (SpawnedCount >= Quantity)
                throw new InvalidValueObjectException(
                    "Spawned count cannot be greater than quantity.");

            SpawnedCount++;
        }

        public bool IsCompleted()
        {
            return SpawnedCount >= Quantity;
        }
    }
}
