using System.Diagnostics.CodeAnalysis;

namespace Rhyous.Reddit
{
    [ExcludeFromCodeCoverage] // Can't unit test Console class without creating a wrapper, and this is already essentially a wrapper.
    internal class ConsoleLogger : ILogger
    {
        private readonly ILogSettings _LogSettings;

        public ConsoleLogger(ILogSettings logSettings)
        {
            _LogSettings = logSettings;
        }

        public void Write(LogLevel level, string message, params string[] msgParams)
        {
            if (level > _LogSettings.LogLevel)
            {
                return; // Ignore log
            }
            if (msgParams.Length > 0) 
            {
                message = string.Format(message, msgParams);
            }
            Console.WriteLine(message);
        }
    }
}
