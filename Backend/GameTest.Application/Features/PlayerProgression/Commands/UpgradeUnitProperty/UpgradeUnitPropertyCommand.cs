using MediatR;

namespace GameTest.Application.Features.PlayerProgression.Commands.UpgradeUnitProperty
{
    public class UpgradeUnitPropertyCommand : IRequest
    {
        public int Id { get; init; }
        public int PlayerId { get; init; }
    }
}
