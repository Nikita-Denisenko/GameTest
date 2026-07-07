using FluentValidation;

namespace GameTest.Application.Features.Runs.Queries.GetRuns
{
    public class GetRunsQueryValidator : AbstractValidator<GetRunsQuery>
    {
        public GetRunsQueryValidator()
        {
            RuleFor(x => x.PlayerId)
                .GreaterThan(0)
                .WithMessage("Player Id must be greater than 0.");
            
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page must be greater than 0.");

            RuleFor(x => x.Size)
                .InclusiveBetween(1, 100)
                .WithMessage("Size must be between 1 and 100.");
        }
    }
}
