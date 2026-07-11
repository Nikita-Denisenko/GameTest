namespace GameTest.Application.Features.PlayerProgression.Commands.UpgradeWeaponProperty
{
    public record UpgradeWeaponPropertyResult
    {
        public int PlayerWeaponPropertyId { get; init; }
        public int NewLevel { get; init; }
        public double NewValue { get; init; }
        public int NewPlayerGold { get; init; }
        public int? NextLevelPrice { get; init; }
        public double? NextLevelValue { get; init; }
    }
}
