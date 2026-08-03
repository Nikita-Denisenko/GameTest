using Assets.Scripts.Entities;
using Assets.Scripts.StaticData;
using Assets.Scripts.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Factories
{
    public class WaveFactory
    {
        public Wave Create(WaveData data)
        {
            var enemies = data.Enemies
                .Select(CreateWaveEnemy)
                .ToList();

            return new Wave(
                data.Id,
                data.Number,
                data.StartSecond,
                data.EndSecond,
                enemies);
        }

        public IReadOnlyCollection<Wave> CreateMany(
            IEnumerable<WaveData> data)
        {
            return data
                .Select(Create)
                .ToList();
        }

        private WaveEnemy CreateWaveEnemy(
            WaveEnemyData data)
        {
            var quantityRange = new EnemyQuantityRange(
                data.QuantityRange.Min,
                data.QuantityRange.Max);

            return new WaveEnemy(
                data.EnemyId,
                quantityRange,
                data.SpawnInterval);
        }
    }
}
