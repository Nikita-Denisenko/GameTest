using Assets.Scripts.Entities;
using Assets.Scripts.Exceptions.Game;
using Assets.Scripts.Factories;
using Assets.Scripts.Game;
using Assets.Scripts.GameData;
using System.Linq;

namespace Assets.Scripts.Services
{
    public class WaveService
    {
        private readonly GameSession _gameSession;
        private readonly Catalog _catalog;
        private readonly WaveFactory _waveFactory;
        private readonly SpawnService _spawnService;

        public WaveService(
            GameSession gameSession,
            Catalog catalog,
            WaveFactory waveFactory,
            SpawnService spawnService)
        {
            _gameSession = gameSession;
            _catalog = catalog;
            _waveFactory = waveFactory;
            _spawnService = spawnService;
        }

        public Wave GetCurrentWave()
        {
            var wave =
                _gameSession.CurrentWave;

            if (wave == null)
                throw new NotFoundException(
                    nameof(Wave),
                    "current");

            return wave;
        }

        public bool HasNextWave()
        {
            var currentWave =
                GetCurrentWave();

            return _catalog.Waves.Values
                .Any(wave =>
                    wave.Number ==
                    currentWave.Number + 1);
        }

        public void StartNewWave()
        {
            var currentWave =
                GetCurrentWave();

            var newWaveData =
                _catalog.Waves.Values
                    .FirstOrDefault(wave =>
                        wave.Number ==
                        currentWave.Number + 1);

            if (newWaveData == null)
                throw new NoMoreWavesException(
                    $"Cannot start a new wave. " +
                    $"Current wave number: {currentWave.Number}. " +
                    $"No more waves available.");

            var newWave =
                _waveFactory.Create(
                    newWaveData);

            _gameSession.ChangeWave(
                newWave);

            _spawnService.StartSpawnEnemies();
        }
    }
}
