using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Core.Decorator
{
    public sealed class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepository()
            : this(Enumerable.Empty<Product>())
        {
        }

        public ProductRepository(IEnumerable<Product> products)
        {
            _products = new List<Product>(products);
        }

        public IEnumerable<Product> All()
        {
            return _products.AsReadOnly();
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public bool Remove(Product product)
        {
            return _products.Remove(product);
        }
    }
}
