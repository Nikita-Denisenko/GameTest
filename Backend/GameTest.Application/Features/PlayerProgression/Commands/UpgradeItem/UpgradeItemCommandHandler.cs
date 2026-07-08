using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.PlayerProgression.Commands.UpgradeItem
{
    public class UpgradeItemCommandHandler : IRequestHandler<UpgradeItemCommand>
    {
        private readonly IAppDbContext _context;

        public UpgradeItemCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpgradeItemCommand command, CancellationToken ct)
        {
            var player = await _context.Players
                .FirstOrDefaultAsync(p => p.Id == command.PlayerId, ct);

            if (player == null)
                throw new KeyNotFoundException($"Player with ID {command.PlayerId} not found");

            var playerItem = await _context.PlayerItems
               .Include(pi => pi.Item)
               .FirstOrDefaultAsync(
                   pi => pi.Id == command.Id &&
                   pi.PlayerId == command.PlayerId,
               ct);

            if (playerItem == null)
                throw new KeyNotFoundException($"PlayerItem with ID {command.Id} not found");

            var upgradePrice = playerItem.NextLevelPrice 
                ?? throw new InvalidOperationException("You have reached the maximum level for this item.");

            player.SpendGold(upgradePrice);

            playerItem.UpLevel();

            await _context.SaveChangesAsync(ct);
        }
    }
}
