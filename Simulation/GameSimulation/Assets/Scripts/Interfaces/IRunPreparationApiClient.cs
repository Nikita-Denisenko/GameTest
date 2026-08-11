using Assets.Scripts.GameData.Runs;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Scripts.Api.Interfaces
{
    public interface IRunPreparationApiClient
    {
        Task<RunPreparationData> GetPreparationAsync(
            int playerUnitId,
            int arenaId,
            int? catId,
            string token,
            CancellationToken ct = default);
    }
}
