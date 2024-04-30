using Rhyous.Reddit;
using Rhyous.StringLibrary;

namespace Rhyous.Reddit
{
    internal class LogSettings : ILogSettings
    {
        private readonly IArgs _Args;

        public LogSettings(IArgs args)
        {
            _Args = args;
        }
        public LogLevel LogLevel => _LogLevel ?? (_LogLevel = _Args.Value("LogLevel").To<LogLevel>(LogLevel.Info)).Value;
        private LogLevel? _LogLevel;
    }
}
