using System.ComponentModel.DataAnnotations;

namespace GameTest.Api.Requests.Auth
{
    public record ChangeEmailRequest
    {
        [Required]
        [EmailAddress]
        [MaxLength(254)]
        public string NewEmail { get; init; } = string.Empty;

        [Required]
        [MinLength(8)]
        [MaxLength(64)]
        public string Password { get; init; } = string.Empty;
    }
}
