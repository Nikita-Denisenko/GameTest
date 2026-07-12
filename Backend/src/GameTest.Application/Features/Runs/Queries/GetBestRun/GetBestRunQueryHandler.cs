using GameTest.Application.Features.Runs.ReadModels;
using GameTest.Application.Interfaces;
using GameTest.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Runs.Queries.GetBestRun
{
    public class GetBestRunQueryHandler : IRequestHandler<GetBestRunQuery, RunReadModel>
    {
        private readonly IAppDbContext _context;

        public GetBestRunQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<RunReadModel> Handle(GetBestRunQuery query, CancellationToken ct)
        {
            if (!await _context.Players.AnyAsync(p => p.Id == query.PlayerId, ct))
                throw new NotFoundException($"Player with ID {query.PlayerId} not found.");

            return await _context.Runs
                .AsNoTracking()
                .Where(r => r.PlayerId == query.PlayerId)
                .OrderByDescending(r => r.LevelReached)
                .ThenByDescending(r => r.Kills)
                .ThenByDescending(r => r.GoldEarned)
                .ThenByDescending(r => r.DurationSeconds)
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
                .FirstOrDefaultAsync(ct)
                ?? throw new NotFoundException($"Player with ID {query.PlayerId} has not runs.");
        }
    }
}

