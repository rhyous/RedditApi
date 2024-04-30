namespace Rhyous.Reddit
{
    internal interface ILogger
    {
        public void Write(LogLevel level, string message, params string[] msgParams);
    }
}
