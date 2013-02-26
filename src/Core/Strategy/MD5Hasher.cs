using System.Security.Cryptography;

namespace DesignPatterns.Core.Strategy
{
    public class MD5Hasher: Hasher
    {
        public MD5Hasher()
            : base(MD5.Create())
        {
            
        }
    }
}
