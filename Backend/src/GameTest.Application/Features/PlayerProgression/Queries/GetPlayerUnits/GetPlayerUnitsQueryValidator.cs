using FluentValidation;
using GameTest.Application.Features.PlayerProgression.Queries.GetUnits;

namespace GameTest.Application.Features.PlayerProgression.Queries.GetPlayerUnits
{
    public class GetPlayerUnitsQueryValidator : AbstractValidator<GetPlayerUnitsQuery>
    {
        public GetPlayerUnitsQueryValidator() 
        {
            RuleFor(x => x.PlayerId)
                .GreaterThan(0)
                .WithMessage("Player ID must be a positive number.");

            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than 0.");

            RuleFor(x => x.Size)
                .InclusiveBetween(1, 100)
                .WithMessage("Page size must be between 1 and 100.");
        }
    }
}
