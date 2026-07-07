using FluentValidation;

namespace GameTest.Application.Features.PlayerProfile.Queries.GetProfile
{
    public class GetProfileQueryValidator : AbstractValidator<GetProfileQuery>
    {
        public GetProfileQueryValidator() 
        {
            RuleFor(x => x.PlayerId)
                .GreaterThan(0)
                .WithMessage("PlayerId must be greater than 0.");
        }
    }
}
