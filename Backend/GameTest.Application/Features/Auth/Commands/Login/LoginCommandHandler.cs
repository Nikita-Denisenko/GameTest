using GameTest.Application.Features.Auth.Responses;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;

namespace GameTest.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponse>
    {
        private readonly IAppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginCommandHandler(
            IAppDbContext context,
            IPasswordHasher passwordHasher,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthResponse> Handle(LoginCommand command, CancellationToken ct)
        {
            var email = command.Email.Trim().ToLowerInvariant();

            var player = await _context
                .Players
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Email == email, ct)
                ?? throw new AuthenticationException("Invalid email or password");

            if (!_passwordHasher.Verify(command.Password, player.PasswordHash))
                throw new AuthenticationException("Invalid email or password");

            return new AuthResponse
            {
                AccessToken = _jwtTokenGenerator.GenerateToken(player)
            };
        }
    }
}
