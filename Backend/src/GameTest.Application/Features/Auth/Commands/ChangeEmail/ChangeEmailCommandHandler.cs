using GameTest.Application.Interfaces;
using GameTest.Domain.Exceptions;
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
            var email = command.NewEmail.Trim().ToLowerInvariant();

            var player = await _context.Players
                .FirstOrDefaultAsync(p => p.Id == command.PlayerId, ct)
                ?? throw new NotFoundException($"Player with ID {command.PlayerId} not found");

            if (!_passwordHasher.Verify(command.Password, player.PasswordHash))
                throw new UnauthorizedException("Invalid Password");

            if (await _context.Players.AnyAsync(p => p.Email == email, ct))
                throw new ConflictException("Email already exists");

            player.ChangeEmail(email);

            await _context.SaveChangesAsync(ct);
        }
    }
}
