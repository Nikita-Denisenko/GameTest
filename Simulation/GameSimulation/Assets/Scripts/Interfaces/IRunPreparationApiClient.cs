using Assets.Scripts.GameData.Runs;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Scripts.Api.Interfaces
{
    public interface IRunPreparationApiClient
    {
        Task<RunPreparationData> GetPreparationAsync(
            int playerId,
            CancellationToken ct = default);
    }
}
