namespace TestCoverageCompare.Interfaces;

public interface ILogger
{
    public void Info(string message);

    public void Success(string message);

    public void Warn(string message);

    public void Error(string message);
    public void Error(Exception exception);
}