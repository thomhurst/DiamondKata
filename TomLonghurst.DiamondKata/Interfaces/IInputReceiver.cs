namespace TomLonghurst.DiamondKata.Interfaces;

public interface IInputReceiver
{
    Task<string?> GetInput();
}