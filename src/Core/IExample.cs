
namespace DesignPatterns.Core
{
    public interface IExample
    {
        string Pattern { get; }

        string Description { get; }

        void Run();
    }
}
