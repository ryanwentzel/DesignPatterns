using System.IO;
using Ionic.BZip2;

namespace DesignPatterns.Core.Strategy.Compression
{
    /// <summary>
    /// An <see cref="ICompression"/> strategy that performs BZip2 
    /// compression and decompression.
    /// </summary>
    public sealed class BZip2Compression : ICompression
    {
        public byte[] Compress(Stream inputStream)
        {
            using (var outputStream = new MemoryStream())
            using (var bzip2 = new BZip2OutputStream(outputStream))
            {
                inputStream.WriteTo(bzip2);
                return outputStream.ToArray();
            }
        }

        public byte[] Decompress(Stream inputStream)
        {
            using (var bzip2Stream = new BZip2InputStream(inputStream))
            using (var outputStream = new MemoryStream())
            {
                bzip2Stream.WriteTo(outputStream);
                return outputStream.ToArray();
            }
        }
    }
}
