using System;

namespace DesignPatterns.Core.Decorator
{
    /// <summary>
    /// Logs messages to the console.
    /// </summary>
    public sealed class ConsoleLogger : ILogger
    {
        public void Debug(string message)
        {
            Log(LogLevel.Debug, message);
        }

        public void Info(string message)
        {
            Log(LogLevel.Info, message);
        }

        public void Error(string message)
        {
            Log(LogLevel.Error, message);
        }

        public void Warn(string message)
        {
            Log(LogLevel.Warn, message);
        }

        private static void Log(LogLevel level, string message)
        {
            Console.WriteLine(string.Format("{0:yyyy-MM-dd HH:mm:ss.fff} | {1} | {2}", DateTime.Now, level, message));
        }
    }
}
