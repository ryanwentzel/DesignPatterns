using System.Collections.Generic;

namespace DesignPatterns.Core.Decorator
{
    public sealed class AuditedProductRepository : IProductRepository
    {
        private readonly ILogger _logger;
        private readonly IProductRepository _repository;

        public AuditedProductRepository(IProductRepository repository, ILogger logger)
        {
            Ensure.ArgumentNotNull(repository, "repository");
            Ensure.ArgumentNotNull(logger, "logger");

            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<Product> All()
        {
            return _repository.All();
        }

        public void Add(Product product)
        {
            _repository.Add(product);
            _logger.Info(string.Format("Added product {0}|{1}", product.Id, product.Name));
        }

        public bool Remove(Product product)
        {
            bool result = _repository.Remove(product);
            _logger.Info(string.Format("{0} product {1}|{2}", result ? "Removed" : "Could not remove", product.Id, product.Name));

            return result;
        }
    }
}
