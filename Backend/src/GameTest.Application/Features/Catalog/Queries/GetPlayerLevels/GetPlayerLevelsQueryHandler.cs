using GameTest.Application.Features.Catalog.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Catalog.Queries.GetPlayerLevels
{
    public class GetPlayerLevelsQueryHandler : IRequestHandler<GetPlayerLevelsQuery, IReadOnlyCollection<PlayerLevelReadModel>>
    {
        private readonly IAppDbContext _context;

        public GetPlayerLevelsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<PlayerLevelReadModel>> Handle(GetPlayerLevelsQuery query, CancellationToken ct)
        {
            return await _context.PlayerLevels
                .AsNoTracking()
                .OrderBy(pl => pl.Level)
                .Select(pl => new PlayerLevelReadModel
                {
                    Id = pl.Id,
                    Experience = pl.Experience,
                    Level = pl.Level
                })
                .ToListAsync(ct);
        }
    }
}
