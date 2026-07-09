using GameTest.Application.Features.Auth.Responses;
using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResponse>
    {
        private readonly IAppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPlayerProgressFactory _playerProgressFactory;

        public RegisterCommandHandler(
            IAppDbContext context, 
            IPasswordHasher passwordHasher, 
            IJwtTokenGenerator jwtTokenGenerator,
            IPlayerProgressFactory playerProgressFactory)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _playerProgressFactory = playerProgressFactory;
        }

        public async Task<AuthResponse> Handle(RegisterCommand command, CancellationToken ct)
        {
            bool emailExists = await _context.Players.AnyAsync(p => p.Email == command.Email, ct);

            if (emailExists)
                throw new InvalidOperationException($"This email address is already in use");

            var passwordHash = _passwordHasher.Hash(command.Password);

            var player = new Player(command.Nickname, command.Email, passwordHash);

            await _context.Players.AddAsync(player, ct);
            await _playerProgressFactory.CreateInitialProgressAsync(player, ct);
            await _context.SaveChangesAsync(ct);

            return new AuthResponse 
            { 
                AccessToken = _jwtTokenGenerator.GenerateToken(player) 
            };
        }
    }
}
