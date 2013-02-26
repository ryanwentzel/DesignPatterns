using System.Security.Cryptography;

namespace DesignPatterns.Core.Strategy.Cryptography
{
    public sealed class CryptoParameters
    {
        public SymmetricAlgorithm Algorithm { get; set; }

        public int KeySize { get; set; }

        public int IVSize { get; set; }

        public CryptoParameters(SymmetricAlgorithm algorithm)
        {
            Algorithm = algorithm;
            KeySize = 16;
            IVSize = 16;
        }
    }
}
