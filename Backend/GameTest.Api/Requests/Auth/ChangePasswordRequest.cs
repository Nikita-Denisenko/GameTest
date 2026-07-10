using System.ComponentModel.DataAnnotations;

namespace GameTest.Api.Requests.Auth
{
    public record ChangePasswordRequest
    {
        [Required]
        [MinLength(8)]
        [MaxLength(64)]
        public string CurrentPassword { get; init; } = string.Empty;

        [Required]
        [MinLength(8)]
        [MaxLength(64)]
        public string NewPassword { get; init; } = string.Empty;
    }
}
