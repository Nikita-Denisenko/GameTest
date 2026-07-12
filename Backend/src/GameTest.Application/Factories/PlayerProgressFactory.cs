using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Factories
{
    public class PlayerProgressFactory : IPlayerProgressFactory
    {
        private readonly IAppDbContext _context;

        public PlayerProgressFactory(IAppDbContext context)
        {
            _context = context;
        }

        public async Task CreateInitialProgressAsync(
            Player player,
            CancellationToken ct)
        {
            var units = await _context.Units
                .AsNoTracking()
                .Include(u => u.Properties)
                .ToListAsync(ct);

            var weapons = await _context.Weapons
                .AsNoTracking()
                .Include(w => w.Properties)
                .ToListAsync(ct);

            var items = await _context.Items
                .AsNoTracking()
                .ToListAsync(ct);

            foreach (var unit in units)
            {
                player.AddUnit(new PlayerUnit(unit));
            }

            foreach (var weapon in weapons)
            {
                player.AddWeapon(new PlayerWeapon(weapon));
            }

            foreach (var item in items)
            {
                player.AddItem(new PlayerItem(item));
            }
        }
    }
}
