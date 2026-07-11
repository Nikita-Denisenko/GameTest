using FluentValidation;

namespace GameTest.Application.Features.Runs.Queries.GetBestRun
{
    public class GetBestRunQueryValidator : AbstractValidator<GetBestRunQuery>
    {
        public GetBestRunQueryValidator() 
        {
            RuleFor(x => x.PlayerId)
                .GreaterThan(0)
                .WithMessage("Player Id must be greater than 0.");
        }
    }
}
