using System.Security.Cryptography;

namespace DesignPatterns.Core.Strategy
{
    public abstract class Hasher : Disposable, IHasher
    {
        protected HashAlgorithm Algorithm { get; private set; }

        protected Hasher(HashAlgorithm algorithm)
        {
            Ensure.ArgumentNotNull(algorithm, "algorithm");

            Algorithm = algorithm;
        }

        public byte[] Hash(byte[] input)
        {
            Ensure.ArgumentNotNull(input, "input");

            return Algorithm.ComputeHash(input);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Algorithm != null)
                {
                    Algorithm.Dispose();
                }
            }

            Algorithm = null;
        }
    }
}
