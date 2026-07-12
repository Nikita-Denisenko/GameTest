using MediatR;

namespace GameTest.Application.Features.PlayerProfile.Commands.ChangeNickname
{
    public record ChangeNicknameCommand : IRequest
    {
        public int PlayerId { get; init; }
        public string NewNickname { get; init; } = null!;
    }
}
