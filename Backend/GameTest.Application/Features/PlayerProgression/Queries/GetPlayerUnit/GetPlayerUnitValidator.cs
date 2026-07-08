using FluentValidation;
using GameTest.Application.Features.PlayerProgression.Queries.GetUnit;

namespace GameTest.Application.Features.PlayerProgression.Queries.GetPlayerUnit
{
    public class GetPlayerUnitValidator : AbstractValidator<GetPlayerUnitQuery>
    {
        public GetPlayerUnitValidator() 
        {
            RuleFor(x => x.Id)
                 .GreaterThan(0)
                 .WithMessage("PlayerUnitId must be greater than 0.");

            RuleFor(x => x.PlayerId)
                .GreaterThan(0)
                .WithMessage("PlayerId must be greater than 0.");
        }
    }
}
