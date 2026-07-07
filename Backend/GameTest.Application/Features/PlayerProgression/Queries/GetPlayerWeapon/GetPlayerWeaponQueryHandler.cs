using GameTest.Application.Features.PlayerProgression.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.PlayerProgression.Queries.GetWeapon
{
    public class GetPlayerWeaponQueryHandler : IRequestHandler<GetPlayerWeaponQuery, PlayerWeaponReadModel>
    {
        private readonly IAppDbContext _context;

        public GetPlayerWeaponQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<PlayerWeaponReadModel> Handle(GetPlayerWeaponQuery query, CancellationToken ct)
        {
            var weapon = await _context.PlayerWeapons
                .AsNoTracking()
                .Where(pw => pw.Id == query.Id && pw.PlayerId == query.PlayerId)
                .Select(pw => new PlayerWeaponReadModel
                {
                    Id = pw.Id,
                    Name = pw.Weapon.Name,
                    Description = pw.Weapon.Description,
                    Type = pw.Weapon.Type,
                    Properties = pw.Properties.Select(p => new PlayerWeaponPropertyReadModel
                    {
                        Id = p.Id,
                        StatId = p.WeaponProperty.StatId,
                        StatType = p.WeaponProperty.Stat.Type,
                        Value = p.Value,
                        Level = p.Level,
                        NextLevelValue = p.NextLevelValue,
                        NextLevelPrice = p.NextLevelPrice
                    }).ToList()
                }).FirstOrDefaultAsync(ct);

            if (weapon == null)
                throw new KeyNotFoundException($"Weapon with ID {query.Id} not found");
            
            return weapon;
        }
    }
}
