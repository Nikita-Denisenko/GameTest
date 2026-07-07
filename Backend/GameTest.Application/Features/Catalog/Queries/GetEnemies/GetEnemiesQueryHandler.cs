using GameTest.Application.Features.Catalog.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Catalog.Queries.GetEnemies
{
    public class GetEnemiesQueryHandler : IRequestHandler<GetEnemiesQuery, IReadOnlyCollection<EnemyReadModel>>
    {
        private readonly IAppDbContext _context;

        public GetEnemiesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<EnemyReadModel>> Handle(GetEnemiesQuery query, CancellationToken ct)
        {
            return await _context.Enemies
                .AsNoTracking()
                .Select(e => new EnemyReadModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    EnemyType = e.Type,
                    AttackType = e.AttackType,
                    Properties = e.Properties.Select(p => new EnemyPropertyReadModel
                    {
                        StatId = p.StatId,
                        StatName = p.Stat.Name,
                        Value = p.Value
                    }).ToList()
                })
                .ToListAsync(ct);
        }
    }
}
