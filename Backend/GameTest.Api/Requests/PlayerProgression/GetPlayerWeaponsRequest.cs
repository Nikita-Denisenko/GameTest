using GameTest.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace GameTest.Api.Requests.PlayerProgression
{
    public record GetPlayerWeaponsRequest
    {
        [Range(1, int.MaxValue)]
        public int Page { get; init; } = 1;

        [Range(1, 100)]
        public int Size { get; init; } = 20;

        public WeaponType? Type { get; init; }
    }
}
