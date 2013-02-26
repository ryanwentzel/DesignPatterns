using System.Security.Cryptography;

namespace DesignPatterns.Core.Strategy.Cryptography
{
    /// <summary>
    /// An implementation of <see cref="ISaltGenerator"/> based on <see cref="RandomNumberGenerator"/>.
    /// </summary>
    public sealed class RNGSaltGenerator : ISaltGenerator
    {
        private readonly RandomNumberGenerator _rng;

        public const int MinimumIVLength = 8;

        /// <summary>
        /// Initializes a new instance of the <see cref="RNGSaltGenerator"/> class.
        /// </summary>
        /// <param name="rng">A random number generator.</param>
        public RNGSaltGenerator(RandomNumberGenerator rng)
        {
            Ensure.ArgumentNotNull(rng, "rng");

            _rng = rng;
        }

        public byte[] Generate(int length)
        {
            Ensure.ArgumentNotLessThan(length, MinimumIVLength, "length");

            var buffer = new byte[length];
            _rng.GetNonZeroBytes(buffer);

            return buffer;
        }
    }
}
