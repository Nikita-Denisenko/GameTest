using GameTest.Application.Features.Catalog.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Catalog.Queries.GetWavesInfo
{
    public record GetWavesQuery : IRequest<IReadOnlyCollection<WaveReadModel>>;
}
