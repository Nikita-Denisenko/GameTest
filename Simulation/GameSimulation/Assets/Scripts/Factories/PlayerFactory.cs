using Assets.Scripts.Entities;
using Assets.Scripts.GameData.Runs;
using Assets.Scripts.GameData.StaticData;
using Assets.Scripts.Services;
using Assets.Scripts.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Factories
{
    public class PlayerFactory
    {
        private readonly PlayerUnitFactory _unitFactory;
        private readonly WeaponFactory _weaponFactory;
        private readonly PlayerLevelFactory _levelFactory;
        private readonly SpawnPositionService _spawnPositionService;


        public PlayerFactory(
            PlayerUnitFactory unitFactory,
            WeaponFactory weaponFactory,
            PlayerLevelFactory levelFactory,
            SpawnPositionService spawnPositionService)
        {
            _unitFactory = unitFactory;
            _weaponFactory = weaponFactory;
            _levelFactory = levelFactory;
            _spawnPositionService = spawnPositionService;
        }


        public Player Create(
            RunPreparationData preparation,
            UnitData unitData,
            IReadOnlyCollection<UnitStatData> unitStats,
            RunWeaponData startWeapon,
            WeaponData weaponData,
            IReadOnlyCollection<WeaponStatData> weaponStats,
            IReadOnlyCollection<PlayerLevelData> levels)
        {
            var unit = _unitFactory.Create(
                preparation.Unit,
                unitData,
                unitStats,
                _spawnPositionService.GetPlayerStartPosition());


            var weapon = _weaponFactory.Create(
                startWeapon,
                weaponData,
                weaponStats);


            var playerLevels = levels
                .Select(_levelFactory.Create)
                .ToList();


            return new Player(
                Guid.NewGuid(),
                unit,
                playerLevels,
                new List<Weapon>
                {
                    weapon
                },
                new List<Item>());
        }
    }
}
