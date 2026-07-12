
using MediatR;

namespace GameTest.Application.Features.Auth.Commands.ChangeEmail
{
    public record ChangeEmailCommand : IRequest
    {
        public int PlayerId { get; init; }
        public string NewEmail { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
    }
}
