using System.ComponentModel.DataAnnotations;

namespace GameTest.Api.Requests.PlayerProfile
{
    public record ChangeNicknameRequest
    {
        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        public string NewNickname { get; init; } = string.Empty;
    }
}
