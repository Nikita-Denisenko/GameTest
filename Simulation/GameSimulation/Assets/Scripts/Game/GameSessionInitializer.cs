using Assets.Scripts.Api.Interfaces;
using Assets.Scripts.Factories;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    public class GameSessionInitializer
    {
        private readonly IRunPreparationApiClient _runPreparationApiClient;
        private readonly GameSessionFactory _gameSessionFactory;


        public GameSessionInitializer(
            IRunPreparationApiClient runPreparationApiClient,
            GameSessionFactory gameSessionFactory)
        {
            _runPreparationApiClient = runPreparationApiClient;
            _gameSessionFactory = gameSessionFactory;
        }


        public async Task<GameSession> InitializeAsync(
            int playerUnitId,
            int arenaId,
            string token,
            CancellationToken ct = default)
        {
            var preparation =
                await _runPreparationApiClient
                    .GetPreparationAsync(
                        arenaId,
                        playerUnitId,
                        token,
                        ct);


            return _gameSessionFactory
                .Create(preparation);
        }
    }
}
