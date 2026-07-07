using GameTest.Application.Features.PlayerProfile.ReadModels;
using MediatR;

namespace GameTest.Application.Features.PlayerProfile.Queries.GetProfile
{
    public record GetProfileQuery : IRequest<ProfileReadModel>
    {
        public int PlayerId { get; init; }
    }
}
