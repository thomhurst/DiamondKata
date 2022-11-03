using System.Diagnostics.CodeAnalysis;
using TomLonghurst.DiamondKata.Interfaces;

namespace TomLonghurst.DiamondKata.Services;

[ExcludeFromCodeCoverage]
public class ConsolePrinter : IPrinter
{
    public void Clear()
    {
        Console.Clear();
    }

    public Task Print(string value)
    {
        return Console.Out.WriteLineAsync(value);
    }
}