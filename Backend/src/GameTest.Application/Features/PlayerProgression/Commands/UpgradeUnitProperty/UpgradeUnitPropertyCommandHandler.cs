using GameTest.Application.Interfaces;
using GameTest.Domain.Exceptions;
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
                throw new NotFoundException($"Player with ID {command.PlayerId} not found");

            var playerUnitProperty = await _context.PlayerUnitProperties
                .Include(pup => pup.UnitProperty)
                .FirstOrDefaultAsync(
                    pup => pup.Id == command.Id
                    && pup.PlayerUnit.PlayerId == command.PlayerId,
                ct);

            if (playerUnitProperty == null)
                throw new NotFoundException($"PlayerUnitProperty with ID {command.Id} not found");

            if (!playerUnitProperty.CanUpgrade)
                throw new DomainException("You have reached the maximum level for this unit property.");

            player.SpendGold(playerUnitProperty.NextLevelPrice!.Value);

            playerUnitProperty.UpLevel();

            await _context.SaveChangesAsync(ct);

            return new UpgradeUnitPropertyResult
            {
                PlayerUnitPropertyId = playerUnitProperty.Id,
                NewLevel = playerUnitProperty.Level,
                NewValue = playerUnitProperty.Value,
                NewPlayerGold = player.Gold,
                NextLevelPrice = playerUnitProperty.NextLevelPrice,
                NextLevelValue = playerUnitProperty.NextLevelValue
            };
        }
    }
}
