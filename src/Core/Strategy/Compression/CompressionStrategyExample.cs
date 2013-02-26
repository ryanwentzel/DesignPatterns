using System;
using System.Linq;
using System.Text;

namespace DesignPatterns.Core.Strategy.Compression
{
    public sealed class CompressionStrategyExample : Example
    {
        public CompressionStrategyExample()
            : base("Strategy", "Compression via the Strategy pattern.")
        {   
        }

        protected override void ExecuteExample()
        {
            var dataToCompress = Encoding.UTF8.GetBytes(Data.LoremIpsum);

            var strategies = ScanFor<ICompression>();
            strategies.ForEach(s => 
            {
                var strategy = Activator.CreateInstance(s) as ICompression;
                var compressor = new DataCompressor(strategy);

                var compressedData = compressor.Compress(dataToCompress);
                var decompressedData = compressor.Decompress(compressedData);
                var percentDiff = CalculatePercentDecrease(dataToCompress.Length, compressedData.Length);
                Console.WriteLine("{0,-25} | Size: {1}-->{2} bytes {3:0.00}% diff | Decompression succeeded? {4}", 
                    strategy.GetType().Name, 
                    dataToCompress.Length, 
                    compressedData.Length, 
                    percentDiff, 
                    decompressedData.SequenceEqual(dataToCompress));
            });
        }

        private static double CalculatePercentDecrease(int start, int current)
        {
            return Math.Abs((start - current) / (double)start) * 100;
        }
    }
}
