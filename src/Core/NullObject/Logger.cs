using System;

namespace DesignPatterns.Core.NullObject
{
    public sealed class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
