using GameTest.Application.Features.Catalog.ReadModels;
using MediatR;

namespace GameTest.Application.Features.Catalog.Queries.GetCatalog
{
    public record GetCatalogQuery : IRequest<CatalogReadModel>;
}
