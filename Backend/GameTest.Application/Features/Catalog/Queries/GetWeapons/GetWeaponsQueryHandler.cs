using GameTest.Application.Features.Catalog.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Catalog.Queries.GetWeapons
{
    public class GetWeaponsQueryHandler : IRequestHandler<GetWeaponsQuery, List<WeaponReadModel>>
    {
        private readonly IAppDbContext _context;

        public GetWeaponsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<WeaponReadModel>> Handle(GetWeaponsQuery query, CancellationToken ct)
        {
            return await _context.Weapons
                .AsNoTracking()
                .Select(w => new WeaponReadModel
                {
                    Id = w.Id,
                    Name = w.Name,
                    Description = w.Description,
                    Type = w.Type,
                    Properties = w.Properties.Select(p => new WeaponPropertyReadModel
                    {
                        StatId = p.StatId,
                        StatName = p.Stat.Name,
                        Levels = p.Levels.Select(l => new LevelProgressionReadModel
                        {
                            Level = l.Level,
                            Value = l.Value
                        }).ToList()
                    }).ToList()
                })
                .ToListAsync(ct);
        }
    }
}
        