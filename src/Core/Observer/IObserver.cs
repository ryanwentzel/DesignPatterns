
namespace DesignPatterns.Core.Observer
{
    /// <summary>
    /// Defines an observer
    /// </summary>
    public interface IObserver<in T>
    {
        void Notify(T subject);
    }
}
