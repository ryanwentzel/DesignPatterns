using System.Security.Cryptography;

namespace DesignPatterns.Core.Strategy
{
    public sealed class SHA256Hasher : Hasher
    {
        public SHA256Hasher()
            : base(SHA256Managed.Create())
        {
        }
    }
}
