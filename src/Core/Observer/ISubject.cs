
namespace DesignPatterns.Core.Observer
{
    public interface ISubject<T>
    {
        void Register(IObserver<T> observer);
        void Unregister(IObserver<T> observer);
    }
}
