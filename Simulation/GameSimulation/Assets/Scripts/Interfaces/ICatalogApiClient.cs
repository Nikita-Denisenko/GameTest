using Assets.Scripts.GameData.StaticData;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Scripts.Api.Interfaces
{
    public interface ICatalogApiClient
    {
        Task<CatalogData> GetCatalogAsync(
            CancellationToken ct = default);
    }
}
