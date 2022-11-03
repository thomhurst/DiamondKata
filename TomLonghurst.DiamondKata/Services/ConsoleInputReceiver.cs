using System.Diagnostics.CodeAnalysis;
using TomLonghurst.DiamondKata.Interfaces;

namespace TomLonghurst.DiamondKata.Services;

[ExcludeFromCodeCoverage]
public class ConsoleInputReceiver : IInputReceiver
{
    private readonly IPrinter _printer;

    public ConsoleInputReceiver(IPrinter printer)
    {
        _printer = printer;
    }
    
    public async Task<string?> GetInput()
    {
        await _printer.Print("Enter a character: ");
        return await Console.In.ReadLineAsync();
    }
}