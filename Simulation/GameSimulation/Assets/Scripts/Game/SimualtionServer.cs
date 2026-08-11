using Assets.Scripts.Game;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    public class SimulationServer
    {
        private readonly GameDataInitializer _gameDataInitializer;
        private readonly GameSessionInitializer _gameSessionInitializer;

        private GameSession _currentSession;

        private bool _catalogLoaded;


        public SimulationServer(
            GameDataInitializer gameDataInitializer,
            GameSessionInitializer gameSessionInitializer)
        {
            _gameDataInitializer = gameDataInitializer;
            _gameSessionInitializer = gameSessionInitializer;
        }


        public async Task StartGameAsync(
            int playerUnitId,
            int arenaId,
            int? catId,
            string token,
            CancellationToken ct = default)
        {
            if (!_catalogLoaded)
            {
                await _gameDataInitializer.InitializeAsync(
                    token,
                    ct);

                _catalogLoaded = true;
            }

            _currentSession =
                await _gameSessionInitializer.InitializeAsync(
                    playerUnitId,
                    arenaId,
                    catId,
                    token,
                    ct);
        }

        public void Tick(
            float deltaTime)
        {
            _currentSession?.Tick(
                deltaTime);
        }
    }
}
