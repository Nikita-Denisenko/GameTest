using MediatR;

namespace GameTest.Application.Features.PlayerProgression.Commands.UpgradeItem
{
    public record UpgradeItemCommand : IRequest
    {
        public int Id { get; init; }
        public int PlayerId { get; init; }
    }
}
