namespace UIAutomation.Core.Abstration
{
    public interface ILogging
    {
        void LogLevel(string message);
        void Debug(string message);
        void Information(string message);
        void Error(string message);
        void Warning(string message);
        void Fatal(string message);
    }
}
