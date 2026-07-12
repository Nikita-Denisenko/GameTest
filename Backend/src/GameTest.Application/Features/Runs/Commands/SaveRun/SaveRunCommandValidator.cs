using FluentValidation;

namespace GameTest.Application.Features.Runs.Commands.SaveRun
{
    public class SaveRunCommandValidator : AbstractValidator<SaveRunCommand>
    {
        public SaveRunCommandValidator()
        {
            RuleFor(x => x.PlayerId)
                .GreaterThan(0)
                .WithMessage("Player ID must be a positive number");

            RuleFor(x => x.UnitId)
                .GreaterThan(0)
                .WithMessage("Unit ID must be a positive number");

            RuleFor(x => x.StartedAt)
                .NotEqual(default(DateTime))
                .WithMessage("StartedAt cannot be default");

            RuleFor(x => x.DurationSeconds)
                .GreaterThan(0)
                .WithMessage("Duration must be a positive number");

            RuleFor(x => x.Kills)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Kills cannot be negative");

            RuleFor(x => x.GoldEarned)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Gold earned cannot be negative");

            RuleFor(x => x.LevelReached)
                .GreaterThan(0)
                .WithMessage("Level reached must be a positive number");
        }
    }
}
