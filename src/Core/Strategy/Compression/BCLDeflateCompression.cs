using System.IO;
using System.IO.Compression;

namespace DesignPatterns.Core.Strategy.Compression
{
    public sealed class BCLDeflateCompression : ICompression
    {
        public byte[] Compress(Stream inputStream)
        {
            byte[] result;
            MemoryStream outputStream = null;
            try
            {
                outputStream = new MemoryStream();
                using (var deflateStream = new DeflateStream(outputStream, CompressionMode.Compress))
                {
                    inputStream.WriteTo(deflateStream);
                    result = outputStream.ToArray();
                }
            }
            finally
            {
                if (outputStream != null)
                {
                    outputStream.Dispose();
                }
            }

            return result;
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
