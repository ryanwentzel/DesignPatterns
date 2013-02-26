using System.IO;

namespace DesignPatterns.Core
{
    public static class ByteExtensions
    {
        /// <summary>
        /// Returns a <see cref="Stream"/> that represents the current instance.
        /// </summary>
        /// <param name="buffer">The current instance.</param>
        /// <returns>A <see cref="Stream"/> representing the current instance.</returns>
        public static Stream ToStream(this byte[] buffer)
        {
            var stream = new MemoryStream();
            stream.Write(buffer, 0, buffer.Length);
            stream.Position = 0;

            return stream;
        }
    }
}
