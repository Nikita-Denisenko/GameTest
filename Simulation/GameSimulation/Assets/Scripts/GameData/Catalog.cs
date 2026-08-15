using Assets.Scripts.Exceptions;
using Assets.Scripts.GameData.StaticData;
using Assets.Scripts.StaticData;
using System.Collections.Generic;

namespace Assets.Scripts.GameData
{
    public class Catalog
    {
        public IReadOnlyDictionary<int, EnemyData> Enemies { get; }
        public IReadOnlyDictionary<int, EnemyStatData> EnemyStats { get; }

        public IReadOnlyDictionary<int, ItemData> Items { get; }

        public IReadOnlyDictionary<int, UnitData> Units { get; }
        public IReadOnlyDictionary<int, UnitStatData> UnitStats { get; }

        public IReadOnlyDictionary<int, WeaponData> Weapons { get; }
        public IReadOnlyDictionary<int, WeaponStatData> WeaponStats { get; }

        public IReadOnlyDictionary<int, WaveData> Waves { get; }

        public IReadOnlyDictionary<int, PlayerLevelData> PlayerLevels { get; }

        public IReadOnlyDictionary<int, ArenaData> Arenas { get; }

        public IReadOnlyDictionary<int, CatData> Cats { get; }
        public IReadOnlyDictionary<int, CatStatData> CatStats { get; }



        public Catalog(
            IReadOnlyDictionary<int, EnemyData> enemies,
            IReadOnlyDictionary<int, EnemyStatData> enemyStats,
            IReadOnlyDictionary<int, ItemData> items,
            IReadOnlyDictionary<int, UnitData> units,
            IReadOnlyDictionary<int, UnitStatData> unitStats,
            IReadOnlyDictionary<int, WeaponData> weapons,
            IReadOnlyDictionary<int, WeaponStatData> weaponStats,
            IReadOnlyDictionary<int, WaveData> waves,
            IReadOnlyDictionary<int, PlayerLevelData> playerLevels,
            IReadOnlyDictionary<int, ArenaData> arenas,
            IReadOnlyDictionary<int, CatData> cats,
            IReadOnlyDictionary<int, CatStatData> catStats)
        {
            Enemies = enemies
                ?? throw new CatalogException("Enemies cannot be null.");

            EnemyStats = enemyStats
                ?? throw new CatalogException("Enemy stats cannot be null.");

            Items = items
                ?? throw new CatalogException("Items cannot be null.");

            Units = units
                ?? throw new CatalogException("Units cannot be null.");

            UnitStats = unitStats
                ?? throw new CatalogException("Unit stats cannot be null.");

            Weapons = weapons
                ?? throw new CatalogException("Weapons cannot be null.");

            WeaponStats = weaponStats
                ?? throw new CatalogException("Weapon stats cannot be null.");

            Waves = waves
                ?? throw new CatalogException("Waves cannot be null.");

            PlayerLevels = playerLevels
                ?? throw new CatalogException("Player levels cannot be null.");

            Arenas = arenas
                ?? throw new CatalogException("Arenas cannot be null.");

            Cats = cats
                ?? throw new CatalogException("Cats cannot be null");

            CatStats = catStats
                ?? throw new CatalogException("Cat stats cannot be null");
        }
    }
}
