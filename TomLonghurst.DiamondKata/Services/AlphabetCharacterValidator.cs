using TomLonghurst.DiamondKata.Interfaces;
using TomLonghurst.DiamondKata.Models;

namespace TomLonghurst.DiamondKata.Services;

public class AlphabetCharacterValidator : ICharacterValidator
{
    public ValidationResult Validate(string? input)
    {
        if (!char.TryParse(input, out var character))
        {
            return ValidationResult.Failure($"'{input}' is not a character");
        }
        
        return char.IsLetter(character)
            ? ValidationResult.Success()
            : ValidationResult.Failure($"'{character}' is not alphabetic");
    }
}