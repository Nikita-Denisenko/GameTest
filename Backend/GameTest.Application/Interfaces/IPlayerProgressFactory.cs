using GameTest.Domain.Entities;

namespace GameTest.Application.Interfaces
{
    public interface IPlayerProgressFactory
    {
        Task CreateInitialProgressAsync(Player player, CancellationToken ct);
    }
}
