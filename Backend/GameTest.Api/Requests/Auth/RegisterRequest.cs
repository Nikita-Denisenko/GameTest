using System.ComponentModel.DataAnnotations;

namespace GameTest.Api.Requests.Auth
{
    public record RegisterRequest
    {
        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        public string Nickname { get; init; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(254)]
        public string Email { get; init; } = string.Empty;

        [Required]
        [MinLength(8)]
        [MaxLength(64)]
        public string Password { get; init; } = string.Empty;
    }
}
