
using System;
namespace DesignPatterns.Core.NullObject
{
    public sealed class ClassThatUsesLogger
    {
        private readonly ILogger _logger;

        public ClassThatUsesLogger(ILogger logger)
        {
            Ensure.ArgumentNotNull(logger, "logger");

            _logger = logger;
        }

        public void UseLogger()
        {
            Console.WriteLine("Calling Log(string) on {0}.", _logger.GetType().Name);
            _logger.Log(DateTime.Now.ToShortTimeString());
        }
    }
}
