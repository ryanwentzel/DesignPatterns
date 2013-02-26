using System.IO;
using Ionic.Zlib;

namespace DesignPatterns.Core.Strategy.Compression
{
    /// <summary>
    /// An <see cref="ICompression"/> strategy that performs compression 
    /// and decompression using the Deflate algorithm.
    /// </summary>
    public sealed class DeflateCompression : ICompression
    {
        public byte[] Compress(Stream inputStream)
        {
            using (var outputStream = new MemoryStream())
            using (var deflateStream = new DeflateStream(outputStream, CompressionMode.Compress))
            {
                inputStream.WriteTo(deflateStream);
                return outputStream.ToArray();
            }
        }

        public byte[] Decompress(Stream inputStream)
        {
            using (var deflateStream = new DeflateStream(inputStream, CompressionMode.Decompress))
            using (var outputStream = new MemoryStream())
            {
                deflateStream.WriteTo(outputStream);
                return outputStream.ToArray();
            }
        }
    }
}
