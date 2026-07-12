using FluentValidation;

namespace GameTest.Application.Features.PlayerProgression.Commands.UpgradeItem
{
    public class UpgradeItemCommandValidator : AbstractValidator<UpgradeItemCommand>
    {
        public UpgradeItemCommandValidator() 
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("PlayerItemId must be greater than 0.");

            RuleFor(x => x.PlayerId)
                .GreaterThan(0)
                .WithMessage("PlayerId must be greater than 0.");
        }
    }
}
