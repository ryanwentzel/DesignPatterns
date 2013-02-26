using System.Collections.Generic;

namespace DesignPatterns.Core.Decorator
{
    /// <summary>
    /// Defines a product repository.
    /// </summary>
    public interface IProductRepository
    {
        IEnumerable<Product> All();

        void Add(Product product);

        bool Remove(Product product);
    }
}
