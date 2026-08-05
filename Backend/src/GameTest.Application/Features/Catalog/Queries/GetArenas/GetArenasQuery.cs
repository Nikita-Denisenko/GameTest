using GameTest.Application.Features.Catalog.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Catalog.Queries.GetArenas
{
    public record GetArenasQuery : IRequest<IReadOnlyCollection<ArenaReadModel>>;
}
