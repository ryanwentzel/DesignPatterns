//using System.IO;
//using System.Security.Cryptography;
//using Ionic.Zlib;

//namespace DesignPatterns.Core.Strategy.Compression
//{
//    public sealed class EncryptedZLibCompression : ICompression
//    {
//        private const string Password = "Super_Secret_Password";

//        private static readonly byte[] Salt;

//        static EncryptedZLibCompression()
//        {
//            using (var rng = RandomNumberGenerator.Create())
//            {
//                var buffer = new byte[16];
//                rng.GetNonZeroBytes(buffer);

//                Salt = buffer;
//            }
//        }

//        public byte[] Compress(Stream inputStream)
//        {
//            using (var aes = AesCryptoServiceProvider.Create())
//            using (var pdb = new Rfc2898DeriveBytes(Password, Salt))
//            using (var encryptor = aes.CreateEncryptor(pdb.GetBytes(16), pdb.GetBytes(16)))
//            using (var outputStream = new MemoryStream())
//            using (var zlibStream = new ZlibStream(outputStream, CompressionMode.Compress))
//            using (var cryptoStream = new CryptoStream(zlibStream, encryptor, CryptoStreamMode.Write))
//            {
//                inputStream.WriteTo(cryptoStream);
//                return outputStream.ToArray();
//            }
//        }

//        public byte[] Decompress(Stream inputStream)
//        {
//            using (var aes = AesCryptoServiceProvider.Create())
//            using (var pdb = new Rfc2898DeriveBytes(Password, Salt))
//            using (var decryptor = aes.CreateDecryptor(pdb.GetBytes(16), pdb.GetBytes(16)))
//            using (var cryptoStream = new CryptoStream(inputStream, decryptor, CryptoStreamMode.Read))
//            using (var zlibStream = new ZlibStream(cryptoStream, CompressionMode.Decompress))
//            using (var outputStream = new MemoryStream())
//            {
//                zlibStream.WriteTo(outputStream);
//                return outputStream.ToArray();
//            }
//        }
//    }
//}
