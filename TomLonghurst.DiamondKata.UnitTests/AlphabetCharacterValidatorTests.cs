namespace TomLonghurst.DiamondKata.UnitTests;

public class AlphabetCharacterValidatorTests
{
    private readonly AlphabetCharacterValidator _validator;

    public AlphabetCharacterValidatorTests()
    {
        _validator = new AlphabetCharacterValidator();
    }

    [TestCaseSource(nameof(LowercaseAlphabeticalCharacters))]
    public void When_LowercaseAlphabet_Then_ValidationSuccess(string character)
    {
        var validationResult = _validator.Validate(character);
        
        Assert.That(validationResult.IsValid, Is.True);
    }
    
    [TestCaseSource(nameof(UppercaseAlphabeticalCharacters))]
    public void When_UppercaseAlphabet_Then_ValidationSuccess(string character)
    {
        var validationResult = _validator.Validate(character);
        
        Assert.That(validationResult.IsValid, Is.True);
    }
    
    [TestCaseSource(nameof(NumericCharacters))]
    public void When_Number_Then_ValidationError(string character)
    {
        var validationResult = _validator.Validate(character);
        
        Assert.Multiple(() =>
        {
            Assert.That(validationResult.IsValid, Is.False);
            Assert.That(validationResult.ErrorMessage, Is.EqualTo($"'{character}' is not alphabetic"));
        });
    }
    
    [TestCaseSource(nameof(SpecialCharacters))]
    public void When_Special_Character_Then_ValidationError(string character)
    {
        var validationResult = _validator.Validate(character);
        
        Assert.Multiple(() =>
        {
            Assert.That(validationResult.IsValid, Is.False);
            Assert.That(validationResult.ErrorMessage, Is.EqualTo($"'{character}' is not alphabetic"));
        });
    }
    
    [TestCase("AA")]
    [TestCase("BB")]
    public void When_Multiple_Characters_Then_Validation_Error(string input)
    {
        var validationResult = _validator.Validate(input);
        
        Assert.Multiple(() =>
        {
            Assert.That(validationResult.IsValid, Is.False);
            Assert.That(validationResult.ErrorMessage, Is.EqualTo($"'{input}' is not a character"));
        });
    }

    public static string[] LowercaseAlphabeticalCharacters => Enumerable.Range('a', 26).Select(i => ((char)i).ToString()).ToArray();
    public static string[] UppercaseAlphabeticalCharacters => Enumerable.Range('A', 26).Select(i => ((char)i).ToString()).ToArray();
    public static string[] NumericCharacters => Enumerable.Range('0', 10).Select(i => ((char)i).ToString()).ToArray();
    public static string[] SpecialCharacters = { "@", "!", "\"", "'", "£", "/", "\\", "|", "^", "&" };
}