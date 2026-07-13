using FluentValidation;

namespace GameTest.Application.Features.PlayerProfile.Commands.ChangeNickname
{
    public class ChangeNicknameCommandValidator : AbstractValidator<ChangeNicknameCommand>
    {
        public ChangeNicknameCommandValidator() 
        {
            RuleFor(x => x.NewNickname)
                .NotEmpty()
                .WithMessage("Nickname is required")
                .MaximumLength(32)
                .WithMessage("Nickname cannot exceed 32 characters");
        }
    }
}
