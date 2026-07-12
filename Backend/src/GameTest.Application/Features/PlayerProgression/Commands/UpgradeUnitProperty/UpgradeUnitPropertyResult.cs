namespace GameTest.Application.Features.PlayerProgression.Commands.UpgradeUnitProperty
{
    public record UpgradeUnitPropertyResult
    {
        public int PlayerUnitPropertyId { get; init; }
        public int NewLevel { get; init; }
        public double NewValue { get; init; }
        public int NewPlayerGold { get; init; }
        public int? NextLevelPrice { get; init; }
        public double? NextLevelValue { get; init; }
    }
}
