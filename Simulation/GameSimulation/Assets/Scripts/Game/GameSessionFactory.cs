using Assets.Scripts.Entities;
using Assets.Scripts.Exceptions.Game;
using Assets.Scripts.Game;
using Assets.Scripts.GameData.Runs;
using System.Linq;

namespace Assets.Scripts.Factories
{
    public class GameSessionFactory
    {
        private readonly GameContext _gameContext;
        private readonly PlayerFactory _playerFactory;
        private readonly WaveFactory _waveFactory;
        private readonly ArenaFactory _arenaFactory;


        public GameSessionFactory(
            GameContext gameContext,
            PlayerFactory playerFactory,
            WaveFactory waveFactory,
            ArenaFactory arenaFactory)
        {
            _gameContext = gameContext;
            _playerFactory = playerFactory;
            _waveFactory = waveFactory;
            _arenaFactory = arenaFactory;
        }

        public GameSession Create(
            RunPreparationData preparation)
        {
            var catalog = _gameContext.Catalog;

            var unitData = catalog.Units[
                preparation.Unit.UnitId];


            var startWeaponId = unitData.StartWeaponId;


            var runWeapon = preparation.Weapons
                .First(x => x.WeaponId == startWeaponId);


            var weaponData = _gameContext.Catalog.Weapons[
                startWeaponId];


            var player = _playerFactory.Create(
                preparation,
                unitData,
                catalog.UnitStats.Values.ToList(),
                runWeapon,
                weaponData,
                catalog.WeaponStats.Values.ToList(),
                catalog.PlayerLevels.Values.ToList());

            var firstWaveData = catalog.Waves.Values
                .OrderBy(w => w.Number)
                .FirstOrDefault();

            if (firstWaveData == null)
                throw new NotFoundException(
                    nameof(Wave),
                    "first");

            var firstWave = _waveFactory.Create(firstWaveData);

            var arenaData = _gameContext.Catalog.Arenas[
                preparation.ArenaId];

            var arena = _arenaFactory.Create(
                arenaData);

            return new GameSession(
                arena,
                preparation,
                player,
                firstWave);
        }
    }
}
