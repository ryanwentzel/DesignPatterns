
namespace DesignPatterns.Core.Strategy.Cryptography
{
    public sealed class KeyParameters
    {
        public int KeySize { get; set; }

        public int IVSize { get; set; }

        public string Password { get; set; }

        public byte[] Salt { get; set; }
    }
}
