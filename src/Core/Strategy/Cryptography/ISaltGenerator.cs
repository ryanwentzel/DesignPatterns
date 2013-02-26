
namespace DesignPatterns.Core.Strategy.Cryptography
{
    public interface ISaltGenerator
    {
        byte[] Generate(int length);
    }
}
