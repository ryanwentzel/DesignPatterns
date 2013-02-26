using System.IO;
using Ionic.Zlib;

namespace DesignPatterns.Core.Strategy.Compression
{
    /// <summary>
    /// An <see cref="ICompression"/> strategy that performs GZIP 
    /// compression and decompression.
    /// </summary>
    public sealed class GZipCompression : ICompression
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
