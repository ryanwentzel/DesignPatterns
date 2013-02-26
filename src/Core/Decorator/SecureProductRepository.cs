using System.Collections.Generic;

namespace DesignPatterns.Core.Decorator
{
    /// <summary>
    /// Restricts operations on a product repository based on the user's security level.
    /// </summary>
    public class SecureProductRepository : IProductRepository
    {
        private readonly IProductRepository _repository;
        private readonly IEnvironment _environment;

        public SecureProductRepository(IProductRepository repository, IEnvironment environment)
        {
            Ensure.ArgumentNotNull(repository, "repository");
            Ensure.ArgumentNotNull(environment, "environment");

            _repository = repository;
            _environment = environment;
        }

        public IEnumerable<Product> All()
        {
            // Any user can read from the repository
            return _repository.All();
        }

        public void Add(Product product)
        {
            if (_environment.User.Level != SecurityLevel.Admin)
            {
                throw new NotAuthorizedException(SecurityLevel.Admin);
            }

            _repository.Add(product);
        }

        public bool Remove(Product product)
        {
            if (_environment.User.Level != SecurityLevel.Admin)
            {
                throw new NotAuthorizedException(SecurityLevel.Admin);
            }

            return _repository.Remove(product);
        }
    }
}
