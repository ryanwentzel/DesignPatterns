
using System.IO;
namespace DesignPatterns.Core.Strategy.Compression
{
    public interface ICompression
    {
        byte[] Compress(Stream inputStream);

        byte[] Decompress(Stream inputStream);
    }
}
