using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;
using GameTest.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Runs.Commands.SaveRun
{
    public class SaveRunCommandHandler : IRequestHandler<SaveRunCommand, SaveRunResult>
    {
        private readonly IAppDbContext _context;    

        public SaveRunCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<SaveRunResult> Handle(SaveRunCommand command, CancellationToken ct)
        {
            bool runAlreadyExists = await _context.Runs
               .AnyAsync(r => r.IdempotencyKey == command.IdempotencyKey, ct);

            if (runAlreadyExists)
                throw new RunAlreadyProcessedException();

            var player = await _context.Players
                .FirstOrDefaultAsync(p => p.Id  == command.PlayerId, ct)
                ?? throw new NotFoundException($"Player with ID {command.PlayerId} not found");

            var run = new Run(
                command.IdempotencyKey,
                command.PlayerId,
                command.UnitId,
                command.StartedAt,
                command.DurationSeconds,
                command.Kills,
                command.GoldEarned,
                command.LevelReached);

            player.AddGold(command.GoldEarned);
            player.AddKills(command.Kills);

            await _context.Runs.AddAsync(run, ct);
            await _context.SaveChangesAsync(ct);

            return new SaveRunResult
            {
                RunId = run.Id,
                NewTotalKills = player.TotalKills,
                NewGold = player.Gold,
            };
        }
    }
}
