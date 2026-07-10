using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Auth.Commands.ChangeEmail
{
    public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand>
    {
        private readonly IAppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public ChangeEmailCommandHandler(
            IAppDbContext context, 
            IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task Handle(ChangeEmailCommand command, CancellationToken ct)
        {
            var player = await _context.Players
                .FirstOrDefaultAsync(p => p.Id == command.PlayerId, ct)
                ?? throw new KeyNotFoundException($"Player with ID {command.PlayerId} not found");

            if (!_passwordHasher.Verify(command.Password, player.PasswordHash))
                throw new InvalidOperationException("Invalid Password");

            player.ChangeEmail(command.NewEmail);

            await _context.SaveChangesAsync(ct);
        }
    }
}
