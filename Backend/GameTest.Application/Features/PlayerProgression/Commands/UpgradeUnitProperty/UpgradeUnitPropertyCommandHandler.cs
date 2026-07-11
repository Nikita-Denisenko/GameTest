using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.PlayerProgression.Commands.UpgradeUnitProperty
{
    public class UpgradeUnitPropertyCommandHandler : IRequestHandler<UpgradeUnitPropertyCommand, UpgradeUnitPropertyResult>
    {
        private readonly IAppDbContext _context;

        public UpgradeUnitPropertyCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<UpgradeUnitPropertyResult> Handle(UpgradeUnitPropertyCommand command, CancellationToken ct)
        {
            var player = await _context.Players
                .FirstOrDefaultAsync(p => p.Id == command.PlayerId, ct);

            if (player == null)
                throw new KeyNotFoundException($"Player with ID {command.PlayerId} not found");

            var playerUnitProperty = await _context.PlayerUnitProperties
                .Include(pup => pup.UnitProperty)
                .FirstOrDefaultAsync(
                    pup => pup.Id == command.Id
                    && pup.PlayerUnit.PlayerId == command.PlayerId,
                ct);

            if (playerUnitProperty == null)
                throw new KeyNotFoundException($"PlayerUnitProperty with ID {command.Id} not found");

            var upgradePrice = playerUnitProperty.NextLevelPrice
                ?? throw new InvalidOperationException("You have reached the maximum level for this unit property.");

            player.SpendGold(upgradePrice);

            playerUnitProperty.UpLevel();

            await _context.SaveChangesAsync(ct);

            return new UpgradeUnitPropertyResult
            {
                PlayerUnitPropertyId = playerUnitProperty.Id,
                NewLevel = playerUnitProperty.Level,
                NewValue = playerUnitProperty.Value,
                NewPlayerGold = player.Gold
            };
        }
    }
}
