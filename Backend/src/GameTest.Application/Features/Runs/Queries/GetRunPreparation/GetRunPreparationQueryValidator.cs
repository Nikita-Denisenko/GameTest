using FluentValidation;

namespace GameTest.Application.Features.Runs.Queries.GetRunPreparation
{
    public class GetRunPreparationQueryValidator : AbstractValidator<GetRunPreparationQuery>
    {
        public GetRunPreparationQueryValidator() 
        {
            RuleFor(x => x.PlayerId)
                .GreaterThan(0)
                .WithMessage("PlayerId must be greater than 0");

            RuleFor(x => x.PlayerUnitId)
                .GreaterThan(0)
                .WithMessage("PlayerUnitId must be greater than 0");
        }
    }
}
