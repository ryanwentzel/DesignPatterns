
namespace DesignPatterns.Core.Strategy.Compression
{
    public sealed class DataCompressor
    {
        private readonly ICompression _compression;

        public DataCompressor(ICompression compression)
        {
            Ensure.ArgumentNotNull(compression, "compression");

            _compression = compression;
        }

        public byte[] Compress(byte[] data)
        {
            Ensure.ArgumentNotNull(data, "data");

            using (var stream = data.ToStream())
            {
                var compressedData = _compression.Compress(stream);

                return compressedData;
            }
        }

        public byte[] Decompress(byte[] data)
        {
            Ensure.ArgumentNotNull(data, "data");

            using (var stream = data.ToStream())
            {
                var decompressedData = _compression.Decompress(stream);

                return decompressedData;
            }
        }
    }
}
