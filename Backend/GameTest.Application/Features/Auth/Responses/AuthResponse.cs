namespace GameTest.Application.Features.Auth.Responses
{
    public record AuthResponse
    {
        public string AccessToken { get; init; } = null!;
    }
}
