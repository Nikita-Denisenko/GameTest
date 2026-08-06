using Assets.Scripts.Api.Interfaces;
using Assets.Scripts.GameData;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime;

namespace Assets.Scripts.Game
{
    public class GameDataInitializer
    {
        private readonly ICatalogApiClient _catalogApiClient;
        private readonly CatalogBuilder _catalogBuilder;
        private readonly GameContext _gameContext;


        public GameDataInitializer(
            ICatalogApiClient catalogApiClient,
            CatalogBuilder catalogBuilder,
            GameContext gameContext)
        {
            _catalogApiClient = catalogApiClient;
            _catalogBuilder = catalogBuilder;
            _gameContext = gameContext;
        }


        public async Task InitializeAsync(
            string token,
            CancellationToken ct = default)
        {
            var catalogData =
                await _catalogApiClient
                    .GetCatalogAsync(token, ct);


            var catalog =
                _catalogBuilder
                    .Build(catalogData);


            _gameContext
                .Initialize(catalog);
        }
    }
}
