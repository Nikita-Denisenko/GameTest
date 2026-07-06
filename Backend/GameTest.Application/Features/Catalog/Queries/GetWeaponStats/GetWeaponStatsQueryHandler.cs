using GameTest.Application.Features.Catalog.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Catalog.Queries.GetWeaponStats
{
    public class GetWeaponStatsQueryHandler : IRequestHandler<GetWeaponStatsQuery, List<WeaponStatReadModel>>
    {
        private readonly IAppDbContext _context;

        public GetWeaponStatsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<WeaponStatReadModel>> Handle(GetWeaponStatsQuery query, CancellationToken ct)
        {
            return await _context.WeaponStats
                .AsNoTracking()
                .Select(ws => new WeaponStatReadModel
                {
                    Id = ws.Id,
                    Name = ws.Name,
                    Description = ws.Description
                })
                .ToListAsync(ct);
        }
    }
}
