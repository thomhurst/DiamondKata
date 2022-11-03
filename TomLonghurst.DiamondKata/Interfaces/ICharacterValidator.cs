using TomLonghurst.DiamondKata.Models;

namespace TomLonghurst.DiamondKata.Interfaces;

public interface ICharacterValidator
{
    ValidationResult Validate(string? input);
}