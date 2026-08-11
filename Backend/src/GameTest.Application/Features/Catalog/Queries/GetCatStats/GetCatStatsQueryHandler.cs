using GameTest.Application.Features.Catalog.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Catalog.Queries.GetCatStats
{
    public class GetCatStatsQueryHandler : IRequestHandler<GetCatStatsQuery, IReadOnlyCollection<CatStatReadModel>>
    {
        private readonly IAppDbContext _context;

        public GetCatStatsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<CatStatReadModel>> Handle(GetCatStatsQuery query, CancellationToken ct)
        {
            return await _context.CatStats
                .AsNoTracking()
                .Select(cs => new CatStatReadModel
                {
                    Id = cs.Id,
                    Name = cs.Name,
                    Description = cs.Description,
                    Type = cs.Type,
                })
                .ToListAsync(ct);
        }
    }
}
