
namespace DesignPatterns.Core.NullObject
{
    public sealed class NullLogger : ILogger
    {
        public void Log(string message)
        {
            // do nothing
        }
    }
}
