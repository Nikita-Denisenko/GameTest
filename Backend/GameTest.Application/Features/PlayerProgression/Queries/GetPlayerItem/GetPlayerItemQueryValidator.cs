using FluentValidation;
using GameTest.Application.Features.PlayerProgression.Queries.GetItem;

namespace GameTest.Application.Features.PlayerProgression.Queries.GetPlayerItem
{
    public class GetPlayerItemQueryValidator : AbstractValidator<GetPlayerItemQuery>
    {
        public GetPlayerItemQueryValidator()
        {
            RuleFor(x => x.Id)
                 .GreaterThan(0)
                 .WithMessage("PlayerItemId must be greater than 0.");

            RuleFor(x => x.PlayerId)
                .GreaterThan(0)
                .WithMessage("PlayerId must be greater than 0.");
        }
    }
}
