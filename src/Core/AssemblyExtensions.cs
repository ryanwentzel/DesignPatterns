using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DesignPatterns.Core
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetTypesAssignableFrom<T>(this Assembly assembly)
        {
            var targetType = typeof(T);
            return assembly.GetTypes().Where(x => !x.IsAbstract && targetType.IsAssignableFrom(x));
        }
    }
}
