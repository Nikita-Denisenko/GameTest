using Assets.Scripts.Game;
using Assets.Scripts.GameData;
using Assets.Scripts.GameData.Runs;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class GameSessionFactory
    {
        private readonly Catalog _catalog;

        private readonly PlayerFactory _playerFactory;
        private readonly WaveFactory _waveFactory;


        public GameSessionFactory(
            Catalog catalog,
            PlayerFactory playerFactory,
            WaveFactory waveFactory)
        {
            _catalog = catalog;
            _playerFactory = playerFactory;
            _waveFactory = waveFactory;
        }


        public GameSession Create(
            RunPreparationData preparation,
            Vector2 playerPosition)
        {
            var unitData = _catalog.Units[
                preparation.Unit.UnitId];


            var startWeaponId = unitData.StartWeaponId;


            var runWeapon = preparation.Weapons
                .First(x => x.WeaponId == startWeaponId);


            var weaponData = _catalog.Weapons[
                startWeaponId];


            var player = _playerFactory.Create(
                preparation,
                unitData,
                _catalog.UnitStats.Values.ToList(),
                runWeapon,
                weaponData,
                _catalog.WeaponStats.Values.ToList(),
                _catalog.PlayerLevels.Values.ToList(),
                playerPosition);


            var waves = _waveFactory.CreateMany(
                _catalog.Waves.Values);


            return new GameSession(
                preparation,
                player,
                waves);
        }
    }
}
