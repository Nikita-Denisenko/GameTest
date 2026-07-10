using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand>
    {
        private readonly IAppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public ChangePasswordCommandHandler(
            IAppDbContext context, 
            IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task Handle(ChangePasswordCommand command, CancellationToken ct)
        {
            var player = await _context.Players
                .FirstOrDefaultAsync(p => p.Id == command.PlayerId, ct)
                ?? throw new KeyNotFoundException($"Player with ID {command.PlayerId} not found");

            if (!_passwordHasher.Verify(command.CurrentPassword, player.PasswordHash))
                throw new InvalidOperationException("Invalid Current password");

            player.ChangePassword(_passwordHasher.Hash(command.NewPassword));

            await _context.SaveChangesAsync(ct);
        }
    }
}
