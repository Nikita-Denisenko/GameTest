using GameTest.Application.Features.Runs.ReadModels;
using GameTest.Application.Interfaces;
using GameTest.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Runs.Queries.GetRun
{
    public class GetRunQueryHandler : IRequestHandler<GetRunQuery, RunReadModel>
    {
        private readonly IAppDbContext _context;

        public GetRunQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<RunReadModel> Handle(GetRunQuery query, CancellationToken ct)
        {
            var run = await _context.Runs
                .AsNoTracking()
                .Where(r => r.Id == query.Id && r.PlayerId == query.PlayerId)
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
                .FirstOrDefaultAsync(ct);

            if (run == null)
                throw new NotFoundException($"Run with ID {query.Id} not found.");

            return run;
        }
    }
}
