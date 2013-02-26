using System.Security.Cryptography;

namespace DesignPatterns.Core.Strategy
{
    public class SHA1Hasher : Hasher
    {
        public SHA1Hasher()
            : base(SHA1.Create())
        {
            
        }
    }
}
