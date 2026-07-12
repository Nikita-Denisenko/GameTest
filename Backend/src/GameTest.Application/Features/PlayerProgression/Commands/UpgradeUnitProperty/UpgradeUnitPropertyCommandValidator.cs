using FluentValidation;

namespace GameTest.Application.Features.PlayerProgression.Commands.UpgradeUnitProperty
{
    public class UpgradeUnitPropertyCommandValidator : AbstractValidator<UpgradeUnitPropertyCommand>
    {
        public UpgradeUnitPropertyCommandValidator() 
        {
            RuleFor(x => x.Id)
                 .GreaterThan(0)
                 .WithMessage("PlayerUnitPropertyId must be greater than 0.");

            RuleFor(x => x.PlayerId)
                .GreaterThan(0)
                .WithMessage("PlayerId must be greater than 0.");
        }
    }
}
