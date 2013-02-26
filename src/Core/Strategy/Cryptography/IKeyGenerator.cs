
namespace DesignPatterns.Core.Strategy.Cryptography
{
    public interface IKeyGenerator
    {
        byte[] Generate(string password, byte[] salt, int keyLength);
    }
}
