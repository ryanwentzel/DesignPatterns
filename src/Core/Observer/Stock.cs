using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Core.Observer
{
    public sealed class Stock : ISubject<Stock>
    {
        private static readonly object Locker = new object();

        private readonly List<IObserver<Stock>> _observers;

        public string Symbol { get; private set; }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; NotifyObservers(); }
        }

        public Stock(string symbol)
        {
            Ensure.ArgumentNotNull(symbol, "symbol");

            Symbol = symbol;
            _observers = new List<IObserver<Stock>>();
        }

        public void Register(IObserver<Stock> observer)
        {
            Ensure.ArgumentNotNull(observer, "observer");

            lock(Locker)
            {
                if (_observers.Any(x => x == observer)) return;

                _observers.Add(observer);
            }
        }

        public void Unregister(IObserver<Stock> observer)
        {
            Ensure.ArgumentNotNull(observer, "observer");

            lock(Locker)
            {
                var found = _observers.FirstOrDefault(x => x == observer);
                if (found == null) return;

                _observers.Remove(found);
            }
        }

        private void NotifyObservers()
        {
            IObserver<Stock>[] toNotify = null;
            lock(Locker)
            {
                toNotify = _observers.Where(o => o != null).ToArray();
            }

            if (toNotify == null) return;

            toNotify.ForEach(o => o.Notify(this));
        }
    }
}
