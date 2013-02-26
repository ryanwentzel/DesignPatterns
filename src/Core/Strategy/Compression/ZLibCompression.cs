using System.IO;
using Ionic.Zlib;

namespace DesignPatterns.Core.Strategy.Compression
{
    /// <summary>
    /// An <see cref="ICompression"/> strategy that performs Zlib 
    /// compression and decompression.
    /// </summary>
    public sealed class ZLibCompression : ICompression
    {
        public byte[] Compress(Stream inputStream)
        {
            using (var outputStream = new MemoryStream())
            using (var zlibStream = new ZlibStream(outputStream, CompressionMode.Compress))
            {
                inputStream.WriteTo(zlibStream);
                return outputStream.ToArray();
            }
        }

        public byte[] Decompress(Stream inputStream)
        {
            using (var zlibStream = new ZlibStream(inputStream, CompressionMode.Decompress))
            using (var outputStream = new MemoryStream())
            {
                zlibStream.WriteTo(outputStream);
                return outputStream.ToArray();
            }
        }
    }
}
