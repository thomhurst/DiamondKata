namespace TomLonghurst.DiamondKata.Models;

public record ValidationResult(bool IsValid)
{
    public string? ErrorMessage { get; set; }

    public static ValidationResult Success() => new ValidationResult(true);
    public static ValidationResult Failure(string errorMessage) => new ValidationResult(false) { ErrorMessage = errorMessage };
}