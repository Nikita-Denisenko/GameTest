using GameTest.Domain.Enums;
using MediatR;

namespace GameTest.Application.Features.Runs.Commands.SaveRun
{
    public record SaveRunCommand : IRequest<SaveRunResult>
    {
        public Guid IdempotencyKey { get; init; }
        public int PlayerId { get; init; }
        public int UnitId { get; init; }
        public DateTime StartedAt { get; init; }
        public int DurationSeconds { get; init; }
        public int Kills { get; init; }
        public int GoldEarned { get; init; }
        public int LevelReached { get; init; }
    }
}
