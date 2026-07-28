using GameTest.Application.Features.Catalog.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Catalog.Queries.GetUnits
{
    public class GetUnitsQueryHandler : IRequestHandler<GetUnitsQuery, IReadOnlyCollection<UnitReadModel>>
    {
        private readonly IAppDbContext _context;

        public GetUnitsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<UnitReadModel>> Handle(GetUnitsQuery query, CancellationToken ct)
        {
            return await _context.Units
                .AsNoTracking()
                .Select(unit => new UnitReadModel
                {
                    Id = unit.Id,
                    Name = unit.Name,
                    Description = unit.Description,
                    Type = unit.Type,
                    StartWeaponId = unit.StartWeaponId,
                    StartWeaponName = unit.StartWeapon.Name,
                    PassiveAbility = new PassiveAbilityReadModel
                    {
                        Name = unit.PassiveAbility.Name,
                        Description = unit.PassiveAbility.Description,
                        Bonus = unit.PassiveAbility.Bonus,
                        Type = unit.PassiveAbility.Type
                    },
                    Properties = unit.Properties.Select(p => new UnitPropertyReadModel
                    {
                        StatId = p.StatId,
                        StatName = p.Stat.Name,
                        Levels = p.Levels.Select(l => new LevelProgressionReadModel
                        {
                            Level = l.Level,
                            Value = l.Value,
                            Price = l.Price,
                        }).ToList(),
                        TemporaryLevels = p.TemporaryLevels.Select(tl => new TemporaryLevelReadModel
                        {
                            Level = tl.Level,
                            Value = tl.Value,
                            Price = tl.Price,
                        }).ToList()
                    }).ToList(),
                })
                .ToListAsync(ct);
        }
    }
}
