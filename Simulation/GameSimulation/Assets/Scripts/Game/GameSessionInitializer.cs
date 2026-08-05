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
        private readonly GameServer _gameServer;


        public GameSessionInitializer(
            IRunPreparationApiClient runPreparationApiClient,
            GameSessionFactory gameSessionFactory,
            GameServer gameServer)
        {
            _runPreparationApiClient = runPreparationApiClient;
            _gameSessionFactory = gameSessionFactory;
            _gameServer = gameServer;
        }


        public async Task<GameSession> InitializeAsync(
            int playerId,
            CancellationToken ct = default)
        {
            var preparation =
                await _runPreparationApiClient.GetPreparationAsync(
                    playerId,
                    ct);


            var session =
                _gameSessionFactory.Create(
                    preparation);


            _gameServer.AddSession(session);


            return session;
        }
    }
}
