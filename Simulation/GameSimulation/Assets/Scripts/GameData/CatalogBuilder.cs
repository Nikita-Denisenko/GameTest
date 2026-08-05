using Assets.Scripts.GameData.StaticData;
using Assets.Scripts.StaticData;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.GameData
{
    public sealed class CatalogBuilder
    {
        public Catalog Build(
            IReadOnlyCollection<EnemyData> enemies,
            IReadOnlyCollection<EnemyStatData> enemyStats,
            IReadOnlyCollection<ItemData> items,
            IReadOnlyCollection<UnitData> units,
            IReadOnlyCollection<UnitStatData> unitStats,
            IReadOnlyCollection<WeaponData> weapons,
            IReadOnlyCollection<WeaponStatData> weaponStats,
            IReadOnlyCollection<WaveData> waves,
            IReadOnlyCollection<PlayerLevelData> playerLevels)
        {
            return new Catalog(
                enemies.ToDictionary(x => x.Id),
                enemyStats.ToDictionary(x => x.Id),
                items.ToDictionary(x => x.Id),
                units.ToDictionary(x => x.Id),
                unitStats.ToDictionary(x => x.Id),
                weapons.ToDictionary(x => x.Id),
                weaponStats.ToDictionary(x => x.Id),
                waves.ToDictionary(x => x.Id),
                playerLevels.ToDictionary(x => x.Id));
        }
    }
}
