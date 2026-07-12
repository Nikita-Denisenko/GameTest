using GameTest.Application.Features.Auth.Responses;
using MediatR;

namespace GameTest.Application.Features.Auth.Commands.Register
{
    public record RegisterCommand : IRequest<AuthResponse>
    {
        public string Nickname { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
    }
}
