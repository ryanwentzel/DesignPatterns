
namespace DesignPatterns.Core.Strategy.Cryptography
{
    public interface ICryptoUtility
    {
        byte[] Encrypt(byte[] data, byte[] key, byte[] iv);

        byte[] Encrypt(byte[] data, KeyParameters parameters);

        byte[] Decrypt(byte[] data, byte[] key, byte[] iv);

        byte[] Decrypt(byte[] data, KeyParameters parameters);
    }
}
