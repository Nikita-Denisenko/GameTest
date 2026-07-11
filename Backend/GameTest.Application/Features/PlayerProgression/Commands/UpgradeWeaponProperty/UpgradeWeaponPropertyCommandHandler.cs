using GameTest.Application.Interfaces;
using GameTest.Domain.Exceptions;
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
                throw new NotFoundException($"Player with ID {command.PlayerId} not found");

            var playerWeaponProperty = await _context.PlayerWeaponProperties
                .Include(pwp => pwp.WeaponProperty)
                .FirstOrDefaultAsync(
                    pwp => pwp.Id == command.Id
                    && pwp.PlayerWeapon.PlayerId == command.PlayerId,
                ct);

            if (playerWeaponProperty == null)
                throw new NotFoundException($"PlayerWeaponProperty with ID {command.Id} not found");

            if (!playerWeaponProperty.CanUpgrade)
                throw new DomainException("You have reached the maximum level for this weapon property.");

            player.SpendGold(playerWeaponProperty.NextLevelPrice!.Value);
            playerWeaponProperty.UpLevel();

            await _context.SaveChangesAsync(ct);

            return new UpgradeWeaponPropertyResult
            {
                PlayerWeaponPropertyId = playerWeaponProperty.Id,
                NewLevel = playerWeaponProperty.Level,
                NewValue = playerWeaponProperty.Value,
                NewPlayerGold = player.Gold,
                NextLevelPrice = playerWeaponProperty.NextLevelPrice,
                NextLevelValue = playerWeaponProperty.NextLevelValue,
            };
        }
    }
}
