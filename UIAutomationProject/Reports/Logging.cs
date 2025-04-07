
using Serilog;
using Serilog.Core;
using UIAutomation.Core.Abstration;

namespace UIAutomation.Core.Reports
{
    public class Logging : ILogging
    {
        private readonly IDefaultVariables _idefaultVariables;
        readonly LoggingLevelSwitch _loggingLevelSwitch;
        public Logging(IDefaultVariables idefaultVariables)
        {
            _idefaultVariables = idefaultVariables;
            _loggingLevelSwitch = new LoggingLevelSwitch(Serilog.Events.LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration().MinimumLevel.ControlledBy(_loggingLevelSwitch)
                .WriteTo.File(_idefaultVariables.GetLog, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .Enrich.WithThreadName().CreateLogger();
        }
        public void LogLevel(string level)
        {
            switch (level.ToLower())
            {
                case "error":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Error;
                    break;

                case "Information":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Information;
                    break;

                case "Warning":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Warning;
                    break;

                default:
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Debug;
                    break;
            }
        }
        public void Debug(string message)
        {
            Log.Debug(message);
        }
        public void Error(string message)
        {
            Log.Error(message);
        }
        public void Fatal(string message)
        {
            Log.Fatal(message);
        }
        public void Warning(string message)
        {
            Log.Warning(message);
        }
        public void Information(string message)
        {
            Log.Information(message);
        }
    }
}
