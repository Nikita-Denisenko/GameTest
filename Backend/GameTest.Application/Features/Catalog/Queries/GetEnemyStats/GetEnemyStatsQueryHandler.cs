using GameTest.Application.Features.Catalog.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Catalog.Queries.GetEnemyStats
{
    public class GetEnemyStatsQueryHandler : IRequestHandler<GetEnemyStatsQuery, IReadOnlyCollection<EnemyStatReadModel>>
    {
        private readonly IAppDbContext _context;

        public GetEnemyStatsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<EnemyStatReadModel>> Handle(GetEnemyStatsQuery query, CancellationToken ct)
        {
            return await _context.EnemyStats
                .AsNoTracking()
                .Select(e => new EnemyStatReadModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Type = e.Type
                })
                .ToListAsync(ct);
        }
    }
}
