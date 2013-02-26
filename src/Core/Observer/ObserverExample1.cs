
using System.Linq;
namespace DesignPatterns.Core.Observer
{
    public class ObserverExample1 : Example
    {
        public ObserverExample1()
            : base("Observer", "Stock Ticker observes Stock instances.")
        {
        }

        protected override void ExecuteExample()
        {
            var aapl = new Stock("AAPL") { Price = 527.68m };
            var goog = new Stock("GOOG") { Price = 647.18m };

            var ticker = new StockTicker();
            aapl.Register(ticker);
            goog.Register(ticker);

            Enumerable.Range(1, 10).ForEach(i =>
            {
                decimal value = (decimal)i;
                aapl.Price += value;
                goog.Price += value;
            });

            aapl.Unregister(ticker);
            goog.Unregister(ticker);
        }
    }
}
