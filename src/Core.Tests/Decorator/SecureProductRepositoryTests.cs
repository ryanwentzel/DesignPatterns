using DesignPatterns.Core.Decorator;
using Moq;
using Xunit;

namespace DesignPatterns.Core.Tests.Decorator
{
    public sealed class SecureProductRepositoryTests
    {
        [Fact]
        public void Add_InsufficientSecurityLevel_Throws()
        {
            var environment = new Mock<IEnvironment>();
            environment.SetupGet(env => env.User).Returns(new User { Level = SecurityLevel.User, UserName = "rwentzel" });
            var secureRepo = new SecureProductRepository(new Mock<IProductRepository>().Object, environment.Object);

            Assert.Throws<NotAuthorizedException>(() => secureRepo.Add(new Product { Id = 1, Name = "Product A", Price = 5.99m }));
        }

        [Fact]
        public void Remove_InsufficientSecurityLevel_Throws()
        {
            var environment = new Mock<IEnvironment>();
            environment.SetupGet(env => env.User).Returns(new User { Level = SecurityLevel.User, UserName = "rwentzel" });
            var secureRepo = new SecureProductRepository(new Mock<IProductRepository>().Object, environment.Object);

            Assert.Throws<NotAuthorizedException>(() => secureRepo.Add(new Product { Id = 1, Name = "Product A", Price = 5.99m }));
        }
    }
}
