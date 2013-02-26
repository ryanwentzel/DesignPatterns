using System;

namespace DesignPatterns.Core.Observer
{
    public sealed class StockTicker : IObserver<Stock>
    {
        public void Notify(Stock subject)
        {
            Console.WriteLine("{0} - {1:C}", subject.Symbol, subject.Price);
        }
    }
}
