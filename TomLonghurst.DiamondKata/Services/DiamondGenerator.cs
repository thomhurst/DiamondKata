using TomLonghurst.DiamondKata.Interfaces;

namespace TomLonghurst.DiamondKata.Services;

public class DiamondGenerator : IDiamondGenerator
{
    public string GenerateDiamond(char character)
    {
        var alphabeticIndexOfEndCharacter = char.ToUpper(character) - 'A' + 1;

        var topDiamond = Enumerable.Range('A', alphabeticIndexOfEndCharacter)
            .Select(charIndex =>
            {
                var alphabeticLetter = (char) charIndex;
                
                var alphabeticIndexOfCurrentCharacter = char.ToUpper(alphabeticLetter) - 'A' + 1;
                var middleSpaces = GetMiddleSpaces(alphabeticIndexOfCurrentCharacter);
                var leadingTrailingSpaces = GetLeadingTrailingSpaces(alphabeticIndexOfEndCharacter, alphabeticIndexOfCurrentCharacter);
                
                if (alphabeticLetter == 'A')
                {
                    return $"{leadingTrailingSpaces}{alphabeticLetter}";
                }

                return $"{leadingTrailingSpaces}{alphabeticLetter}{middleSpaces}{alphabeticLetter}";
            })
            .ToArray();

        // Skip the first row as it is the middle
        var bottomDiamond = topDiamond.Reverse().Skip(1);

        var completeDiamond = topDiamond.Concat(bottomDiamond);

        return string.Join(Environment.NewLine, completeDiamond);
    }

    private static string GetLeadingTrailingSpaces(int alphabeticIndexOfEndCharacter, int alphabeticIndexOfCurrentCharacter)
    {
        return new string(' ', alphabeticIndexOfEndCharacter - alphabeticIndexOfCurrentCharacter);
    }

    private static string GetMiddleSpaces(int alphabeticIndexOfCurrentCharacter)
    {
        if (alphabeticIndexOfCurrentCharacter == 1) // A
        {
            return string.Empty;
        }

        const int countOfLettersInRow = 2;
        
        var rowLengthBetweenLettersInclusive = alphabeticIndexOfCurrentCharacter * 2 - 1;
        
        return new string(' ', rowLengthBetweenLettersInclusive - countOfLettersInRow);
    }
}