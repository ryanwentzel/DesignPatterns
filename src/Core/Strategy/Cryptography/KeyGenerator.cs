using System.Security.Cryptography;

namespace DesignPatterns.Core.Strategy.Cryptography
{
    public sealed class KeyGenerator : IKeyGenerator
    {
        public byte[] Generate(string password, byte[] salt, int keyLength)
        {
            Ensure.ArgumentNotNullOrWhiteSpace(password, "password");
            Ensure.ArgumentNotNull(salt, "salt");
            Ensure.ArgumentNotLessThan(keyLength, 1, "keyLength");

            using (var pdb = new Rfc2898DeriveBytes(password, salt))
            {
                return pdb.GetBytes(keyLength);
            }
        }
    }
}
