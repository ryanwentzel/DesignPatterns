
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace DesignPatterns.Core.Strategy.Cryptography
{
    public sealed class EncryptionStrategyExample : Example
    {
        public EncryptionStrategyExample()
            : base("Strategy", "Various encryption algorithms implemented using the strategy pattern.")
        {   
        }

        protected override void ExecuteExample()
        {
            const string dataToEncrypt = "This is sample data to encrypt and decrypt.";
            Console.WriteLine("\nData to encrypt/decrypt: \"{0}\"\n", dataToEncrypt);

            var parameters = new List<CryptoParameters>
            {
                new CryptoParameters(new AesCryptoServiceProvider()),
                new CryptoParameters(new DESCryptoServiceProvider()) { KeySize = 8 },
                new CryptoParameters(new TripleDESCryptoServiceProvider()),
                new CryptoParameters(new RC2CryptoServiceProvider())
            };

            var rng = RandomNumberGenerator.Create();
            ISaltGenerator saltGenerator = new RNGSaltGenerator(rng);
            var password = "MY_SECR3t_P@55w0RD";

            try
            {
                parameters.ForEach(p =>
                {
                    var typeName = p.Algorithm.GetType().Name;
                    ICryptoUtility cryptoUtility = new CryptoUtility(p.Algorithm, new KeyGenerator());
                    var salt = saltGenerator.Generate(8);

                    using (var pdb = new Rfc2898DeriveBytes(password, salt))
                    {
                        var key = pdb.GetBytes(p.KeySize);
                        var iv = pdb.GetBytes(p.IVSize);

                        var encryptedData = cryptoUtility.Encrypt(Encoding.UTF8.GetBytes(dataToEncrypt), key, iv);
                        Console.WriteLine("\n{0} | Encrypted data: {1}", typeName, BitConverter.ToString(encryptedData).Replace("-", ""));

                        var decryptedData = cryptoUtility.Decrypt(encryptedData, key, iv);
                        var decryptedString = Encoding.UTF8.GetString(decryptedData);
                        Console.WriteLine("{0} | Decrypted data: {1}", typeName, decryptedString);

                        Debug.Assert(decryptedString == dataToEncrypt);
                    }
                });

                parameters.ForEach(p =>
                {
                    var typeName = p.Algorithm.GetType().Name;
                    ICryptoUtility cryptoUtility = new CryptoUtility(p.Algorithm, new KeyGenerator());
                    var salt = saltGenerator.Generate(8);
                    var keyParams = new KeyParameters { KeySize = p.KeySize, IVSize = p.IVSize, Password = password, Salt = salt };

                    var encryptedData = cryptoUtility.Encrypt(Encoding.UTF8.GetBytes(dataToEncrypt), keyParams);
                    Console.WriteLine("\n{0} | Encrypted data: {1}", typeName, BitConverter.ToString(encryptedData).Replace("-", ""));

                    var decryptedData = cryptoUtility.Decrypt(encryptedData, keyParams);
                    var decryptedString = Encoding.UTF8.GetString(decryptedData);
                    Console.WriteLine("{0} | Decrypted data: {1}", typeName, Encoding.UTF8.GetString(decryptedData));

                    Debug.Assert(decryptedString == dataToEncrypt);
                });
            }
            finally
            {
                parameters.ForEach(p => p.Algorithm.Dispose());
                rng.Dispose();
            }
        }
    }
}
