using FluentValidation;
using GameTest.Application.Features.PlayerProgression.Queries.GetWeapon;

namespace GameTest.Application.Features.PlayerProgression.Queries.GetPlayerWeapon
{
    public class GetPlayerWeaponQueryValidator : AbstractValidator<GetPlayerWeaponQuery>
    {
        public GetPlayerWeaponQueryValidator() 
        { 
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("PlayerWeaponId must be greater than 0.");

            RuleFor(x => x.PlayerId)
                .GreaterThan(0)
                .WithMessage("PlayerId must be greater than 0.");
        }
    }
}
