namespace TomLonghurst.DiamondKata.Interfaces;

public interface IPrinter
{
    void Clear();
    Task Print(string value);
}