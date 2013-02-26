using System.IO;
using System.Security.Cryptography;

namespace DesignPatterns.Core.Strategy.Cryptography
{
    public sealed class CryptoUtility : ICryptoUtility
    {
        private readonly SymmetricAlgorithm _cryptoAlgorithm;

        private readonly IKeyGenerator _keyGenerator;

        public CryptoUtility(SymmetricAlgorithm algorithm, IKeyGenerator keyGenerator)
        {
            Ensure.ArgumentNotNull(algorithm, "algorithm");
            Ensure.ArgumentNotNull(keyGenerator, "keyGenerator");

            _cryptoAlgorithm = algorithm;
            _cryptoAlgorithm.Padding = PaddingMode.ISO10126;

            _keyGenerator = keyGenerator;
        }

        public byte[] Encrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (var encryptor = _cryptoAlgorithm.CreateEncryptor(key, iv))
            using (var stream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();

                return stream.ToArray();
            }
        }

        public byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (var stream = new MemoryStream())
            using (var decryptor = _cryptoAlgorithm.CreateDecryptor(key, iv))
            using (var cryptoStream = new CryptoStream(stream, decryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();

                return stream.ToArray();
            }
        }

        public byte[] Encrypt(byte[] data, KeyParameters parameters)
        {
            Ensure.ArgumentNotNull(parameters, "parameters");

            var key = _keyGenerator.Generate(parameters.Password, parameters.Salt, parameters.KeySize);
            var iv = _keyGenerator.Generate(parameters.Password, parameters.Salt, parameters.IVSize);

            return Encrypt(data, key, iv);
        }

        public byte[] Decrypt(byte[] data, KeyParameters parameters)
        {
            Ensure.ArgumentNotNull(parameters, "parameters");

            var key = _keyGenerator.Generate(parameters.Password, parameters.Salt, parameters.KeySize);
            var iv = _keyGenerator.Generate(parameters.Password, parameters.Salt, parameters.IVSize);

            return Decrypt(data, key, iv);
        }
    }
}
