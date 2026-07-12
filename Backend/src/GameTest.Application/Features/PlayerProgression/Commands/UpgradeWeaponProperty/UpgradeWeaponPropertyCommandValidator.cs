using FluentValidation;

namespace GameTest.Application.Features.PlayerProgression.Commands.UpgradeWeaponProperty
{
    public class UpgradeWeaponPropertyCommandValidator : AbstractValidator<UpgradeWeaponPropertyCommand>
    {
        public UpgradeWeaponPropertyCommandValidator() 
        {
            RuleFor(x => x.Id)
                 .GreaterThan(0)
                 .WithMessage("PlayerWeaponPropertyId must be greater than 0.");

            RuleFor(x => x.PlayerId)
                .GreaterThan(0)
                .WithMessage("PlayerId must be greater than 0.");
        }
    }
}
