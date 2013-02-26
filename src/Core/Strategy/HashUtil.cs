using System;
using System.Text;

namespace DesignPatterns.Core.Strategy
{
    /// <summary>
    /// Represents a hashing utility.
    /// </summary>
    public static class HashUtil
    {
        /// <summary>
        /// Hashes the specified input using the specified <see cref="IHasher"/>.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="hasher"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Hash(string input, IHasher hasher, Encoding encoding = null)
        {
            var hash = hasher.Hash((encoding ?? Encoding.UTF8).GetBytes(input));

            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}
