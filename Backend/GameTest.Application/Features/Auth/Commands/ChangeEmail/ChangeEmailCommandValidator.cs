using FluentValidation;

namespace GameTest.Application.Features.Auth.Commands.ChangeEmail
{
    public class ChangeEmailCommandValidator : AbstractValidator<ChangeEmailCommand>
    {
        public ChangeEmailCommandValidator() 
        {
            RuleFor(x => x.PlayerId)
                .GreaterThan(0)
                .WithMessage("PlayerId must be greater than 0.");

            RuleFor(x => x.NewEmail)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid email format")
                .MaximumLength(256)
                .WithMessage("Email cannot exceed 256 characters");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(8)
                .WithMessage("Password must contain at least 8 characters")
                .MaximumLength(64)
                .WithMessage("Password cannot exceed 64 characters");
        }
    }
}
