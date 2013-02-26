using System;

namespace DesignPatterns.Core
{
    public static class Ensure
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the specified parameter is null.
        /// </summary>
        /// <typeparam name="T">The parameter's type.</typeparam>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The parameter name.</param>
        public static void ArgumentNotNull<T>(T parameter, string parameterName = "") where T : class
        {
            if (parameter == null) throw new ArgumentNullException(parameterName);
        }

        public static void ArgumentNotLessThan(int parameter, int minimumValue, string parameterName = "")
        {
            if (parameter < minimumValue)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        public static void ArgumentNotNullOrWhiteSpace(string parameter, string parameterName = "")
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            if (string.IsNullOrWhiteSpace(parameter))
            {
                throw new ArgumentException("Value cannot consist of only whitespace.");
            }
        }
    }
}
