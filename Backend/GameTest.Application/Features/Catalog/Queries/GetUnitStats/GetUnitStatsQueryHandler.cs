using GameTest.Application.Features.Catalog.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Catalog.Queries.GetUnitStats
{
    public class GetUnitStatsQueryHandler : IRequestHandler<GetUnitStatsQuery, List<UnitStatReadModel>>
    {
        private readonly IAppDbContext _context;

        public GetUnitStatsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UnitStatReadModel>> Handle(GetUnitStatsQuery query, CancellationToken ct)
        {
            return await _context.UnitStats
                .AsNoTracking()
                .Select(s => new UnitStatReadModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Type = s.Type
                })
                .ToListAsync(ct);
        }
    }
}
