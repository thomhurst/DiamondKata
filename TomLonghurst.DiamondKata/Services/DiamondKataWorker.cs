using TomLonghurst.DiamondKata.Exceptions;
using TomLonghurst.DiamondKata.Interfaces;

namespace TomLonghurst.DiamondKata.Services;

public class DiamondKataWorker
{
    private readonly IInputReceiver _inputReceiver;
    private readonly ICharacterValidator _characterValidator;
    private readonly IDiamondGenerator _diamondGenerator;
    private readonly IPrinter _printer;

    public DiamondKataWorker(
        IInputReceiver inputReceiver,
        ICharacterValidator characterValidator,
        IDiamondGenerator diamondGenerator,
        IPrinter printer
        )
    {
        _inputReceiver = inputReceiver;
        _characterValidator = characterValidator;
        _diamondGenerator = diamondGenerator;
        _printer = printer;
    }

    public async Task Start(string[] args)
    {
        var character = await GetCharacterInput(args);

        var diamond = _diamondGenerator.GenerateDiamond(character);

        await _printer.Print(diamond);
    }

    private async Task<char> GetCharacterInput(string[] args)
    {
        if (TryGetInputFromProgramArguments(args, out var character))
        {
            return character;
        }

        var input = await _inputReceiver.GetInput();

        var validationResult = _characterValidator.Validate(input);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.ErrorMessage!);
        }
        
        _printer.Clear();
        return char.Parse(input!);
    }

    private bool TryGetInputFromProgramArguments(string[] args, out char character)
    {
        if (args.Any())
        {
            var input = args.First();

            var validationResult = _characterValidator.Validate(input);

            if (validationResult.IsValid)
            {
                character = char.Parse(input);
                return true;
            }
        }

        character = default;
        return false;
    }
}