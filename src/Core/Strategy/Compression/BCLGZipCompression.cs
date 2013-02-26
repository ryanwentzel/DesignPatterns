using System.IO;
using System.IO.Compression;

namespace DesignPatterns.Core.Strategy.Compression
{
    public sealed class BCLGZipCompression : ICompression
    {
        public byte[] Compress(Stream inputStream)
        {
            using (var outputStream = new MemoryStream())
            using (var gzipStream = new GZipStream(outputStream, CompressionMode.Compress))
            {
                inputStream.WriteTo(gzipStream);
                return outputStream.ToArray();
            }
        }

        public byte[] Decompress(Stream inputStream)
        {
            using (var gzipStream = new GZipStream(inputStream, CompressionMode.Decompress))
            using (var outputStream = new MemoryStream())
            {
                gzipStream.WriteTo(outputStream);
                return outputStream.ToArray();
            }
        }
    }
}
