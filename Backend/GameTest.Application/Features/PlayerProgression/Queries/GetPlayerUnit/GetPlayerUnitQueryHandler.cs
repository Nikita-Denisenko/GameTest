using GameTest.Application.Features.Catalog.ReadModels;
using GameTest.Application.Features.PlayerProgression.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.PlayerProgression.Queries.GetUnit
{
    public class GetPlayerUnitQueryHandler : IRequestHandler<GetPlayerUnitQuery, PlayerUnitReadModel>
    {
        private readonly IAppDbContext _context;

        public GetPlayerUnitQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<PlayerUnitReadModel> Handle(GetPlayerUnitQuery query, CancellationToken ct)
        {
            var unit = await _context.PlayerUnits
                .AsNoTracking()
                .Where(pu => pu.Id == query.Id && pu.PlayerId == query.PlayerId)
                .Select(pu => new PlayerUnitReadModel
                {
                    Id = pu.Id,
                    Name = pu.Unit.Name,
                    Description = pu.Unit.Description,
                    Type = pu.Unit.Type,
                    Properties = pu.Properties.Select(p => new PlayerUnitPropertyReadModel
                    {
                        Id = p.Id,
                        StatId = p.UnitProperty.StatId,
                        StatName = p.UnitProperty.Stat.Name,
                        StatType = p.UnitProperty.Stat.Type,
                        Value = p.Value,
                        Level = p.Level,
                        NextLevelValue = p.NextLevelValue,
                        NextLevelPrice = p.NextLevelPrice,
                        MaxLevel = p.UnitProperty.Levels.Max(l => l.Level)
                    }).ToList(),
                    PassiveAbility = new PassiveAbilityReadModel
                    {
                        Name = pu.Unit.PassiveAbility.Name,
                        Description = pu.Unit.PassiveAbility.Description,
                        Bonus = pu.Unit.PassiveAbility.Bonus,
                        Type = pu.Unit.PassiveAbility.Type
                    },
                    StartWeaponId = pu.Unit.StartWeaponId,
                    StartWeaponName = pu.Unit.StartWeapon.Name
                })
                .FirstOrDefaultAsync(ct);

            if (unit == null)
                throw new KeyNotFoundException($"PlayerUnit with ID {query.Id} not found");

            return unit;
        }
    }
}
