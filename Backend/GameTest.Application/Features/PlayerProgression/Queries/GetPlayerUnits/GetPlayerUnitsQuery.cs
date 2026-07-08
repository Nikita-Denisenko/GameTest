using GameTest.Application.Features.PlayerProgression.ReadModels;
using GameTest.Domain.Enums;
using MediatR;

namespace GameTest.Application.Features.PlayerProgression.Queries.GetUnits
{
    public record GetPlayerUnitsQuery : IRequest<IReadOnlyCollection<PlayerUnitListReadModel>>
    {
        public int PlayerId { get; init; }
        public UnitType? Type { get; init; }
        public int Page { get; init; }
        public int Size { get; init; }
    }
}
