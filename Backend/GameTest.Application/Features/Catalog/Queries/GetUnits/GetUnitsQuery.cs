using GameTest.Application.Features.Catalog.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Catalog.Queries.GetUnits
{
    public record GetUnitsQuery : IRequest<List<UnitReadModel>>;
}
