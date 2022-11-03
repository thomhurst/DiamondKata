using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using TomLonghurst.DiamondKata.Interfaces;
using TomLonghurst.DiamondKata.Services;

namespace TomLonghurst.DiamondKata;

[ExcludeFromCodeCoverage]
public static class Program
{
    public static async Task Main(string[] args)
    {
        var services = new ServiceCollection()
            .AddTransient<IInputReceiver, ConsoleInputReceiver>()
            .AddTransient<ICharacterValidator, AlphabetCharacterValidator>()
            .AddTransient<IDiamondGenerator, DiamondGenerator>()
            .AddTransient<IPrinter, ConsolePrinter>()
            .AddTransient<DiamondKataWorker>()
            .BuildServiceProvider();

        await services.GetRequiredService<DiamondKataWorker>()
            .Start(args);
    }
}