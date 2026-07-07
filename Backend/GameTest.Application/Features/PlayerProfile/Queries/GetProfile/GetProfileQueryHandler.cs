using GameTest.Application.Features.PlayerProfile.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.PlayerProfile.Queries.GetProfile
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, ProfileReadModel>
    {
        private readonly IAppDbContext _context;

        public GetProfileQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ProfileReadModel> Handle(GetProfileQuery query, CancellationToken ct)
        {
            var profile = await _context.Players
                .Where(p => p.Id == query.PlayerId)
                .Select(p => new ProfileReadModel
                {
                    Nickname = p.Nickname,
                    Email = p.Email,
                    RegisteredAt = p.RegisteredAt,
                    Gold = p.Gold,
                    TotalKills = p.TotalKills
                })
                .FirstOrDefaultAsync(ct);

            if (profile == null)
                throw new KeyNotFoundException($"Player with ID {query.PlayerId} not found.");
            
            return profile;
        }
    }
}
