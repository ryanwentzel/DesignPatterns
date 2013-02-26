using System;
using System.Collections.Generic;

namespace DesignPatterns.Core
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Performs the specified action on each element of the <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The <see cref="IEnumerable{T}"/> containing elements on which to perform an action.</param>
        /// <param name="action">The <see cref="Action{T}"/> delegate to perform on each element of the <see cref="IEnumerable{T}"/>.</param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            Ensure.ArgumentNotNull(action, "action");

            foreach (var item in collection)
            {
                action(item);
            }
        }

        /// <summary>
        /// Performs the specified action on each element of the <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The <see cref="IEnumerable{T}"/> containing elements on which to perform an action.</param>
        /// <param name="action">The <see cref="Action{T}"/> delegate to perform on each element of the <see cref="IEnumerable{T}"/>.</param>
        /// <remarks>This method does the same thing as <see cref="ForEach"/>.</remarks>
        public static void Do<T>(this IEnumerable<T> collection, Action<T> action)
        {
            Ensure.ArgumentNotNull(action, "action");

            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}
