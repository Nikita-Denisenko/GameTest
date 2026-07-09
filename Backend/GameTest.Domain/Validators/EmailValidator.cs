using System.Text.RegularExpressions;

namespace GameTest.Domain.Validators;

public static class EmailValidator
{
    private static readonly Regex EmailRegex = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public static bool IsValid(string email)
    {
        return !string.IsNullOrWhiteSpace(email)
            && EmailRegex.IsMatch(email);
    }
}