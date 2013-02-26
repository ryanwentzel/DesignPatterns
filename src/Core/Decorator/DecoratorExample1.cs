
namespace DesignPatterns.Core.Decorator
{
    public sealed class DecoratorExample1 : Example
    {
        public DecoratorExample1()
            : base("Decorator", "Audited Repository adds logging to Product Repository")
        {
            
        }

        protected override void ExecuteExample()
        {
            IProductRepository repository =
                new AuditedProductRepository(new ProductRepository(), new ConsoleLogger());

            repository.Add(new Product { Id = 1, Name = "Product A", Price = 5.99m });
            repository.Add(new Product { Id = 2, Name = "Product B", Price = 25.99m });
        }
    }
}
