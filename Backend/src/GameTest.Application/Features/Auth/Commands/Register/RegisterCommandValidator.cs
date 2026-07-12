using FluentValidation;

namespace GameTest.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Nickname)
                .NotEmpty()
                .WithMessage("Nickname is required")
                .MaximumLength(32)
                .WithMessage("Nickname cannot exceed 32 characters");

            RuleFor(x => x.Email)
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
