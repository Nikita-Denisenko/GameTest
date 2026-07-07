using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.PlayerProfile.Commands.ChangeNickname
{
    public class ChangeNicknameCommandHandler : IRequestHandler<ChangeNicknameCommand>
    {
        private readonly IAppDbContext _context;

        public ChangeNicknameCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ChangeNicknameCommand query, CancellationToken ct)
        {
            var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == query.PlayerId, ct)
                ?? throw new KeyNotFoundException("Player with ID {query.PlayerId} not found");

            player.ChangeNickname(query.NewNickname);

            await _context.SaveChangesAsync(ct);
        }
    }
}
