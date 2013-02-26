using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Core.Decorator
{
    public class DecoratorExample2 : Example
    {
        public DecoratorExample2()
            : base("Decorator", "Secure Repository adds security to Product Repository")
        {    
        }

        protected override void ExecuteExample()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product A", Price = 5.99m },
                new Product { Id = 2, Name = "Product B", Price = 25.99m }
            };

            IProductRepository repo = 
                new SecureProductRepository(
                    new AuditedProductRepository(new ProductRepository(products), new ConsoleLogger()), 
                    new EnvironmentImpl(new User { UserName = "rwentzel", Level = SecurityLevel.User }));

            var count = repo.All().Count();
            Console.WriteLine("Repo contains {0} products.", count);

            try
            {
                repo.Add(new Product { Id = 3, Name = "Product C", Price = 10.99m });
            }
            catch (NotAuthorizedException exception)
            {
                Console.WriteLine("Error adding product: {0}", exception.Message);
            }

            try
            {
                repo.Remove(products[0]);
            }
            catch (NotAuthorizedException exception)
            {
                Console.WriteLine("Error removing product: {0}", exception.Message);
            }
        }
    }
}
