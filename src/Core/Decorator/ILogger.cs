
namespace DesignPatterns.Core.Decorator
{
    /// <summary>
    /// Defines a simple logger
    /// </summary>
    public interface ILogger
    {
        void Debug(string message);

        void Info(string message);

        void Error(string message);

        void Warn(string message);
    }

    public enum LogLevel
    {
        Debug,
        Error,
        Info,
        Warn
    }
}
