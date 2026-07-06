using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Runs.Commands.SaveRun
{
    public class SaveRunCommandHandler : IRequestHandler<SaveRunCommand>
    {
        private readonly IAppDbContext _context;    

        public SaveRunCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(SaveRunCommand command, CancellationToken ct)
        {
            bool runAlreadyExists = await _context.Runs
                .AnyAsync(r => r.IdempotencyKey == command.IdempotencyKey, ct);

            if (runAlreadyExists)
                throw new InvalidOperationException("You cannot save a run that already exists.");

            var run = new Run(
                command.IdempotencyKey,
                command.PlayerId,
                command.UnitId,
                command.StartedAt,
                command.DurationSeconds,
                command.Kills,
                command.GoldEarned,
                command.LevelReached);

            await _context.Runs.AddAsync(run, ct);
            await _context.SaveChangesAsync(ct);
        }
    }
}
