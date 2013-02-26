using DesignPatterns.Core.Decorator;
using Moq;
using Xunit;

namespace DesignPatterns.Core.Tests.Decorator
{
    public sealed class AuditedProductRepositoryTests
    {
        [Fact]
        public void Add_AddsToRepository()
        {
            var prodRepo = new Mock<IProductRepository>();
            var auditedRepo = new AuditedProductRepository(prodRepo.Object, new Mock<ILogger>().Object);

            auditedRepo.Add(new Product { Id = 1, Name = "Product A", Price = 5.99m });

            prodRepo.Verify(repo => repo.Add(It.IsAny<Product>()));
        }

        [Fact]
        public void Add_LogsMessage()
        {
            var prodRepo = new Mock<IProductRepository>();
            var logger = new Mock<ILogger>();
            var auditedRepo = new AuditedProductRepository(prodRepo.Object, logger.Object);

            auditedRepo.Add(new Product { Id = 1, Name = "Product A", Price = 5.99m });

            logger.Verify(l => l.Info(It.IsAny<string>()));
        }

        [Fact]
        public void Remove_RemovesFromRepository()
        {
            var prodRepo = new Mock<IProductRepository>();
            var auditedRepo = new AuditedProductRepository(prodRepo.Object, new Mock<ILogger>().Object);
            
            auditedRepo.Remove(new Product { Id = 1, Name = "Product A", Price = 5.99m });

            prodRepo.Verify(repo => repo.Remove(It.IsAny<Product>()));
        }

        [Fact]
        public void Remove_LogsMessage()
        {
            var logger = new Mock<ILogger>();
            var auditedRepo = new AuditedProductRepository(new Mock<IProductRepository>().Object, logger.Object);

            auditedRepo.Remove(new Product { Id = 1, Name = "Product A", Price = 5.99m });

            logger.Verify(l => l.Info(It.IsAny<string>()));
        }
    }
}
