using GameTest.Application.Features.PlayerProgression.ReadModels;
using GameTest.Application.Interfaces;
using GameTest.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.PlayerProgression.Queries.GetItem
{
    public class GetPlayerItemQueryHandler : IRequestHandler<GetPlayerItemQuery, PlayerItemReadModel>
    {
        private readonly IAppDbContext _context;

        public GetPlayerItemQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<PlayerItemReadModel> Handle(GetPlayerItemQuery query, CancellationToken ct)
        {
            var item = await _context.PlayerItems
                .AsNoTracking()
                .Where(pi => pi.Id == query.Id && pi.PlayerId == query.PlayerId)
                .Select(pi => new PlayerItemReadModel
                {
                    Id = pi.Id,
                    Name = pi.Item.Name,
                    Description = pi.Item.Description,
                    Type = pi.Item.Type,
                    Bonus = pi.Bonus,
                    Level = pi.Level,
                    NextLevelPrice = pi.NextLevelPrice,
                    NextLevelBonus = pi.NextLevelBonus,
                    MaxLevel = pi.Item.Effect.Levels.Max(l => l.Level),
                    Effect = new PlayerItemEffectReadModel
                    {
                        Name = pi.Item.Effect.Name,
                        Description = pi.Item.Effect.Description,
                        Type = pi.Item.Effect.Type
                    }
                })
                .FirstOrDefaultAsync(ct);

            if (item == null) 
                throw new NotFoundException($"PlayerItem with ID {query.Id} not found");

            return item;
        }
    }
}
