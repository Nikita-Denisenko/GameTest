using MediatR;

namespace GameTest.Application.Features.Auth.Commands.ChangePassword
{
    public record ChangePasswordCommand : IRequest
    {
        public int PlayerId { get; init; }
        public string CurrentPassword { get; init; } = string.Empty;
        public string NewPassword { get; init; } = string.Empty;
    }
}
