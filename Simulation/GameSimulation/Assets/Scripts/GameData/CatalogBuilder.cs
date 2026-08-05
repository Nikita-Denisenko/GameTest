using Assets.Scripts.GameData.StaticData;
using System.Linq;

namespace Assets.Scripts.GameData
{
    public sealed class CatalogBuilder
    {
        public Catalog Build(
            CatalogData data)
        {
            return new Catalog(
                data.Enemies.ToDictionary(x => x.Id),
                data.EnemyStats.ToDictionary(x => x.Id),
                data.Items.ToDictionary(x => x.Id),
                data.Units.ToDictionary(x => x.Id),
                data.UnitStats.ToDictionary(x => x.Id),
                data.Weapons.ToDictionary(x => x.Id),
                data.WeaponStats.ToDictionary(x => x.Id),
                data.Waves.ToDictionary(x => x.Id),
                data.PlayerLevels.ToDictionary(x => x.Id),
                data.Arenas.ToDictionary(x => x.Id));
        }
    }
}
