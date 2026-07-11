namespace GameTest.Application.Features.PlayerProgression.Commands.UpgradeItem
{
    public record UpgradeItemResult
    {
        public int PlayerItemId { get; init; }
        public int NewLevel { get; init; }
        public double NewEffectBonus { get; init; }
        public int NewPlayerGold { get; init; }
        public int? NextLevelPrice { get; init; }
        public double? NextLevelEffectBonus { get; init; }
    }
}
