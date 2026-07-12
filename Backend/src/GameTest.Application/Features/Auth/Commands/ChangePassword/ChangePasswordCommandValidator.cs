using FluentValidation;

namespace GameTest.Application.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator() 
        {
            RuleFor(x => x.PlayerId)
                .GreaterThan(0)
                .WithMessage("PlayerId must be greater than 0.");

            RuleFor(x => x.CurrentPassword)
                .NotEmpty()
                .WithMessage("Current password is required")
                .MinimumLength(8)
                .WithMessage("Current password must contain at least 8 characters")
                .MaximumLength(64)
                .WithMessage("Current password cannot exceed 64 characters");

            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .WithMessage("New password is required")
                .MinimumLength(8)
                .WithMessage("New password must contain at least 8 characters")
                .MaximumLength(64)
                .WithMessage("New password cannot exceed 64 characters");
        }
    }
}
