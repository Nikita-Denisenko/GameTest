using MediatR;

namespace GameTest.Application.Features.PlayerProgression.Commands.UpgradeItem
{
    public record UpgradeItemCommand : IRequest<UpgradeItemResult>
    {
        public int Id { get; init; }
        public int PlayerId { get; init; }
    }
}
