using GameTest.Application.Features.Runs.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Runs.Queries.GetRuns
{
    public class GetRunsQueryHandler : IRequestHandler<GetRunsQuery, IReadOnlyCollection<RunReadModel>>
    {
        private readonly IAppDbContext _context;

        public GetRunsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<RunReadModel>> Handle(GetRunsQuery query, CancellationToken ct)
        {
            var runs = _context.Runs
                .AsNoTracking()
                .Where(r => r.PlayerId == query.PlayerId);

            runs = query.NewestFirst 
                ? runs.OrderByDescending(r => r.StartedAt) 
                : runs.OrderBy(r => r.StartedAt);

            return await runs
                .Skip((query.Page - 1) * query.Size)
                .Take(query.Size)
                .Select(r => new RunReadModel
                {
                    Id = r.Id,
                    UnitId = r.UnitId,
                    UnitName = r.Unit.Name,
                    StartedAt = r.StartedAt,
                    DurationSeconds = r.DurationSeconds,
                    Kills = r.Kills,
                    GoldEarned = r.GoldEarned,
                    LevelReached = r.LevelReached
                })
                .ToListAsync(ct);
        }
    }
}
