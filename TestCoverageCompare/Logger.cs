
using Ardalis.GuardClauses;
using TestCoverageCompare.Interfaces;

namespace TestCoverageCompare;

public class Logger : ILogger
{
    public void Info(string message)
    {
        Guard.Against.NullOrWhiteSpace(message);
        Write(ConsoleColor.Cyan, message);
    }
    
    public void Success(string message)
    {
        Guard.Against.NullOrWhiteSpace(message);
        Write(ConsoleColor.Green, message);
    }

    public void Warn(string message)
    {
        Guard.Against.NullOrWhiteSpace(message);
        Write(ConsoleColor.Yellow, message);
    }
    
    public void Error(string message)
    {
        Guard.Against.NullOrWhiteSpace(message);
        Write(ConsoleColor.Red, message);
    }
    
    public void Error(Exception exception)
    {
        Guard.Against.Null(exception);
        Write(ConsoleColor.Red, exception.Message + exception.StackTrace);
    }

    private void Write(ConsoleColor color, string message)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}