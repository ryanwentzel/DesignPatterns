using System.IO;

namespace DesignPatterns.Core.Strategy.Compression
{
    public static class StreamExtensions
    {
        /// <summary>
        /// Writes data from the stream to the specified output stream.
        /// </summary>
        /// <param name="inputStream">The stream to read from.</param>
        /// <param name="outputStream">The stream to write to.</param>
        /// <param name="closeOutputStream">True if the output stream should be closed after all data from 
        /// the input stream has been written; otherwise false.</param>
        public static void WriteTo(this Stream inputStream, Stream outputStream, bool closeOutputStream = true)
        {
            Ensure.ArgumentNotNull(outputStream, "outputStream");

            byte[] buffer = new byte[2048];
            int bytesRead;
            while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                outputStream.Write(buffer, 0, bytesRead);
            }

            if (closeOutputStream)
            {
                outputStream.Close();
            }
        }
    }
}
