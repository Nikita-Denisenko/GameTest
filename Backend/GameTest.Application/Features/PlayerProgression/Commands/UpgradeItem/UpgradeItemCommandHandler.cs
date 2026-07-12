using GameTest.Application.Interfaces;
using GameTest.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.PlayerProgression.Commands.UpgradeItem
{
    public class UpgradeItemCommandHandler : IRequestHandler<UpgradeItemCommand, UpgradeItemResult>
    {
        private readonly IAppDbContext _context;

        public UpgradeItemCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<UpgradeItemResult> Handle(UpgradeItemCommand command, CancellationToken ct)
        {
            var player = await _context.Players
                .FirstOrDefaultAsync(p => p.Id == command.PlayerId, ct);

            if (player == null)
                throw new NotFoundException($"Player with ID {command.PlayerId} not found");

            var playerItem = await _context.PlayerItems
               .Include(pi => pi.Item)
               .FirstOrDefaultAsync(
                   pi => pi.Id == command.Id &&
                   pi.PlayerId == command.PlayerId,
               ct);

            if (playerItem == null)
                throw new NotFoundException($"PlayerItem with ID {command.Id} not found");

            if (!playerItem.CanUpgrade)
                throw new DomainException("You have reached the maximum level for this item.");

            player.SpendGold(playerItem.NextLevelPrice!.Value); 
            playerItem.UpLevel();

            await _context.SaveChangesAsync(ct);

            return new UpgradeItemResult
            {
                PlayerItemId = playerItem.Id,
                NewLevel = playerItem.Level,
                NewEffectBonus = playerItem.Bonus,
                NewPlayerGold = player.Gold,
                NextLevelPrice = playerItem.NextLevelPrice,
                NextLevelEffectBonus = playerItem.NextLevelBonus,
            };
        }
    }
}
