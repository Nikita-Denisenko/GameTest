using Assets.Scripts.StaticData;
using System;

namespace Assets.Scripts.GameData.StaticData
{
    [Serializable]
    public class CatalogData
    {
        public EnemyData[] Enemies;
        public EnemyStatData[] EnemyStats;

        public ItemData[] Items;

        public UnitData[] Units;
        public UnitStatData[] UnitStats;

        public WeaponData[] Weapons;
        public WeaponStatData[] WeaponStats;

        public WaveData[] Waves;

        public PlayerLevelData[] PlayerLevels;

        public ArenaData[] Arenas;
    }
}