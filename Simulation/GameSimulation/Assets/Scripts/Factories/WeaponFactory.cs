using Assets.Scripts.Entities;
using Assets.Scripts.GameData.Runs;
using Assets.Scripts.GameData.StaticData;
using Assets.Scripts.Interfaces;
using Assets.Scripts.StaticData;
using Assets.Scripts.ValueObjects;
using System.Linq;

namespace Assets.Scripts.Factories
{
    public class WeaponFactory
    {
        private readonly IIdGenerator _idGenerator;

        public WeaponFactory(IIdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
        }

        public Weapon Create(
            RunWeaponData runWeapon,
            WeaponData weaponData,
            CatalogData catalog)
        {
            var properties = runWeapon.Properties
                .Select(runProperty =>
                {
                    var stat = catalog.WeaponStats
                        .First(x => x.Id == runProperty.StatId);

                    var propertyData = weaponData.Properties
                        .First(x => x.StatId == runProperty.StatId);

                    var temporaryLevels = propertyData.TemporaryLevels
                        .Select(x => new PropertyLevel(
                            x.Level,
                            x.Bonus))
                        .ToList();

                    return new WeaponProperty(
                        stat.Name,
                        stat.Id,
                        stat.Type,
                        runProperty.Value,
                        temporaryLevels);
                })
                .ToList();


            var levels = weaponData.TemporaryUpgradeLevels
                .Select(x => new UpgradeLevel(
                    x.Level,
                    x.Price))
                .ToList();


            return new Weapon(
                _idGenerator.Generate(),
                weaponData.Name,
                weaponData.Type,
                properties,
                levels);
        }
    }
}
