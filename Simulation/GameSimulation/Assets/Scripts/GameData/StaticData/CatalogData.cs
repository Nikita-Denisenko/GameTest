using Assets.Scripts.StaticData;
using System.Collections.Generic;

namespace Assets.Scripts.GameData.StaticData
{
    public class CatalogData
    {
        public IReadOnlyCollection<EnemyData> Enemies { get; }
        public IReadOnlyCollection<EnemyStatData> EnemyStats { get; }

        public IReadOnlyCollection<ItemData> Items { get; }

        public IReadOnlyCollection<UnitData> Units { get; } 
        public IReadOnlyCollection<UnitStatData> UnitStats { get; }

        public IReadOnlyCollection<WeaponData> Weapons { get; }
        public IReadOnlyCollection<WeaponStatData> WeaponStats { get; }

        public IReadOnlyCollection<WaveData> Waves { get; }
        public IReadOnlyCollection<PlayerLevelData> PlayerLevels { get; }
    }
}
