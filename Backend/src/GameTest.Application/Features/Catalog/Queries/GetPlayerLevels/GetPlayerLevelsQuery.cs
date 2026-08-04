using GameTest.Application.Features.Catalog.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Catalog.Queries.GetPlayerLevels
{
    public class GetPlayerLevelsQuery : IRequest<IReadOnlyCollection<PlayerLevelReadModel>>;
}
