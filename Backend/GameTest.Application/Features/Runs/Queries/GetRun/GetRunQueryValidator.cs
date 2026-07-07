using FluentValidation;

namespace GameTest.Application.Features.Runs.Queries.GetRun
{
    public class GetRunQueryValidator : AbstractValidator<GetRunQuery>
    {
        public GetRunQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Run Id must be greater than 0.");

            RuleFor(x => x.PlayerId)
                .GreaterThan(0)
                .WithMessage("Player Id must be greater than 0.");
        }
    }
}
