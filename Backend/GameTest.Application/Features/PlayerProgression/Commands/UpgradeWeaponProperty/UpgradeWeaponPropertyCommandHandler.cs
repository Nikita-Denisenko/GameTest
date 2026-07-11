using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.PlayerProgression.Commands.UpgradeWeaponProperty
{
    public class UpgradeWeaponPropertyCommandHandler : IRequestHandler<UpgradeWeaponPropertyCommand, UpgradeWeaponPropertyResult>
    {
        private readonly IAppDbContext _context;

        public UpgradeWeaponPropertyCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<UpgradeWeaponPropertyResult> Handle(UpgradeWeaponPropertyCommand command, CancellationToken ct)
        {
            var player = await _context.Players
                .FirstOrDefaultAsync(p => p.Id == command.PlayerId, ct);

            if (player == null)
                throw new KeyNotFoundException($"Player with ID {command.PlayerId} not found");

            var playerWeaponProperty = await _context.PlayerWeaponProperties
                .Include(pwp => pwp.WeaponProperty)
                .FirstOrDefaultAsync(
                    pwp => pwp.Id == command.Id
                    && pwp.PlayerWeapon.PlayerId == command.PlayerId,
                ct);

            if (playerWeaponProperty == null)
                throw new KeyNotFoundException($"PlayerWeaponProperty with ID {command.Id} not found");

            var upgradePrice = playerWeaponProperty.NextLevelPrice
                ?? throw new InvalidOperationException("You have reached the maximum level for this weapon property.");

            player.SpendGold(upgradePrice);

            playerWeaponProperty.UpLevel();

            await _context.SaveChangesAsync(ct);

            return new UpgradeWeaponPropertyResult
            {
                PlayerWeaponPropertyId = playerWeaponProperty.Id,
                NewLevel = playerWeaponProperty.Level,
                NewValue = playerWeaponProperty.Value,
                NewPlayerGold = player.Gold
            };
        }
    }
}
