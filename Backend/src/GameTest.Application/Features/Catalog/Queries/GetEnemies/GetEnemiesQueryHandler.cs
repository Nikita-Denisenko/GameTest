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
                    }).ToList(),
                    MovementType = e.MovementType,
                    Loot = new EnemyLootReadModel
                    {
                        Gold = new GoldRangeReadModel
                        {
                            Min = e.Loot.Gold.Min,
                            Max = e.Loot.Gold.Max
                        },
                        Experience = new ExperienceRangeReadModel
                        {
                            Min = e.Loot.Experience.Min,
                            Max = e.Loot.Experience.Max
                        },
                        Items = e.Loot.Items.Select(i => new ItemDropReadModel
                        {
                            ItemId = i.ItemId,
                            Chance = i.Chance
                        }).ToList()
                    }
                })
                .ToListAsync(ct);
        }
    }
}
