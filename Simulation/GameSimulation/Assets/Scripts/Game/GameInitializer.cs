using Assets.Scripts.Api.Interfaces;
using Assets.Scripts.GameData;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    public class GameInitializer
    {
        private readonly ICatalogApiClient _catalogApiClient;
        private readonly CatalogBuilder _catalogBuilder;
        private readonly GameContext _gameContext;


        public GameInitializer(
            ICatalogApiClient catalogApiClient,
            CatalogBuilder catalogBuilder,
            GameContext gameContext)
        {
            _catalogApiClient = catalogApiClient;
            _catalogBuilder = catalogBuilder;
            _gameContext = gameContext;
        }


        public async Task InitializeAsync(
            CancellationToken ct = default)
        {
            var catalogData =
                await _catalogApiClient
                    .GetCatalogAsync(ct);


            var catalog =
                _catalogBuilder
                    .Build(catalogData);


            _gameContext
                .Initialize(catalog);
        }
    }
}
