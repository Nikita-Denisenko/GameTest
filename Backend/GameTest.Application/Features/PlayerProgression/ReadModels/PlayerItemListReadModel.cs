using GameTest.Domain.Enums;

namespace GameTest.Application.Features.PlayerProgression.ReadModels
{
    public record PlayerItemListReadModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public ItemType Type { get; init; }
    }
}
