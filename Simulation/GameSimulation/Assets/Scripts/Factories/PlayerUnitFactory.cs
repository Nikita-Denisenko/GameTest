using Assets.Scripts.Entities;
using Assets.Scripts.GameData.Runs;
using Assets.Scripts.Interfaces;
using Assets.Scripts.StaticData;
using Assets.Scripts.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class PlayerUnitFactory
    {
        private readonly IIdGenerator _idGenerator;

        public PlayerUnitFactory(
            IIdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
        }

        public PlayerUnit Create(
            RunUnitData runUnit,
            UnitData unitData,
            IReadOnlyCollection<UnitStatData> stats,
            Vector2 position)
        {
            var properties = runUnit.Properties
                .Select(runProperty =>
                {
                    var stat = stats
                        .First(x => x.Id == runProperty.StatId);

                    var propertyData = unitData.Properties
                        .First(x => x.StatId == runProperty.StatId);

                    var levels = propertyData.TemporaryLevels
                        .Select(x => new PropertyLevel(
                            x.Level,
                            x.Bonus))
                        .ToList();

                    return new UnitProperty(
                        stat.Name,
                        stat.Id,
                        stat.Type,
                        runProperty.Value,
                        levels);
                })
                .ToList();


            var upgradeLevels = unitData.TemporaryUpgradeLevels
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
                upgradeLevels);
        }
    }
}
