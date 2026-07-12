using GameTest.Application.Features.PlayerProgression.Queries.GetWeapons;
using GameTest.Application.Features.PlayerProgression.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.PlayerProgression.Queries.GetPlayerWeapons
{
    public class GetPlayerWeaponsQueryHandler : IRequestHandler<GetPlayerWeaponsQuery, IReadOnlyCollection<PlayerWeaponListReadModel>>
    {
        private readonly IAppDbContext _context;

        public GetPlayerWeaponsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<PlayerWeaponListReadModel>> Handle(GetPlayerWeaponsQuery query, CancellationToken ct)
        {
            var weapons = _context.PlayerWeapons
               .AsNoTracking()
               .Where(pw => pw.PlayerId == query.PlayerId);

            if (query.Type != null)
                weapons = weapons.Where(pw => pw.Weapon.Type == query.Type);

            weapons = weapons.OrderBy(pw => pw.Weapon.Name);

            return await weapons
            .Skip((query.Page - 1) * query.Size)
            .Take(query.Size)
            .Select(pw => new PlayerWeaponListReadModel
            {
                Id = pw.Id,
                Name = pw.Weapon.Name,
                Type = pw.Weapon.Type,
            })
            .ToListAsync(ct);
        }
    }
}
