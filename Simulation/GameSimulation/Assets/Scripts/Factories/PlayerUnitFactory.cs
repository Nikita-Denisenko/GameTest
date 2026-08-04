using Assets.Scripts.Entities;
using Assets.Scripts.GameData.Runs;
using Assets.Scripts.GameData.StaticData;
using Assets.Scripts.Interfaces;
using Assets.Scripts.StaticData;
using Assets.Scripts.ValueObjects;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class PlayerUnitFactory
    {
        private readonly IIdGenerator _idGenerator;

        public PlayerUnitFactory(IIdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
        }


        public PlayerUnit Create(
            RunUnitData runUnit,
            UnitData unitData,
            CatalogData catalog,
            Vector2 position)
        {
            var properties = runUnit.Properties
                .Select(runProperty =>
                {
                    var stat = catalog.UnitStats
                        .First(x => x.Id == runProperty.StatId);


                    var propertyData = unitData.Properties
                        .First(x => x.StatId == runProperty.StatId);


                    var temporaryLevels = propertyData.TemporaryLevels
                        .Select(x => new PropertyLevel(
                            x.Level,
                            x.Bonus))
                        .ToList();


                    return new UnitProperty(
                        stat.Name,
                        stat.Id,
                        stat.Type,
                        runProperty.Value,
                        temporaryLevels);
                })
                .ToList();


            var levels = unitData.TemporaryUpgradeLevels
                .Select(x => new UpgradeLevel(
                    x.Level,
                    x.Price))
                .ToList();


            var passiveAbility = new PassiveAbility(
                unitData.PassiveAbility.Name,
                unitData.PassiveAbility.Type,
                unitData.PassiveAbility.Bonus);


            return new PlayerUnit(
                _idGenerator.Generate(),
                unitData.Name,
                position,
                unitData.Type,
                passiveAbility,
                properties,
                levels);
        }
    }
}
