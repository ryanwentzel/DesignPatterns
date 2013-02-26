using System;
using System.Collections.Generic;
using System.Reflection;

namespace DesignPatterns.Core
{
    public abstract class Example : IExample
    {
        public string Pattern { get; private set; }

        public string Description { get; private set; }

        protected Example(string pattern, string description = "")
        {
            Ensure.ArgumentNotNull(pattern, "pattern");
            Pattern = pattern;
            Description = description;
        }

        public void Run()
        {
            Console.WriteLine("\n########## {0} Pattern ##########\n", Pattern);
            if (!string.IsNullOrWhiteSpace(Description))
            {
                Console.WriteLine("{0}\n", Description);
            }
            ExecuteExample();
            Console.WriteLine("\n########################################");
        }

        protected IEnumerable<Type> ScanFor<T>()
        {
            return Assembly.GetExecutingAssembly().GetTypesAssignableFrom<T>();
        }

        protected abstract void ExecuteExample();
    }
}
