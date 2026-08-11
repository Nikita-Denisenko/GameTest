using FluentValidation;

namespace GameTest.Application.Features.Runs.Commands.PrepareRun
{
    public class PrepareRunCommandValidator : AbstractValidator<PrepareRunCommand>
    {
        public PrepareRunCommandValidator() 
        {
            RuleFor(x => x.PlayerId)
                .GreaterThan(0)
                .WithMessage("PlayerId must be greater than 0");

            RuleFor(x => x.PlayerUnitId)
                .GreaterThan(0)
                .WithMessage("PlayerUnitId must be greater than 0");

            RuleFor(x => x.ArenaId)
                .GreaterThan(0)
                .WithMessage("ArenaId must be greater than 0");

            RuleFor(x => x.CatId)
                .GreaterThan(0)
                .WithMessage("CatId must be greater than 0");
        }
    }
}
