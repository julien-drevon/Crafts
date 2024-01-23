namespace AopExemple.Tests.Loggers;

public class MonSpyLogger : ILog
{
    private bool _isLog = false;

    public bool IsLog { get => _isLog; }

    public void Log(string message)
    {
        _isLog = true;
    }
}