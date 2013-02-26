using System;
using DesignPatterns.Core;
using Ninject;
using Ninject.Extensions.Conventions;

namespace DesignPatterns.ExampleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Title = "Design Patterns Example Runner";
                Console.BufferHeight = Console.BufferHeight + 300;
                Console.WindowHeight = Console.LargestWindowHeight - 5;

                IKernel kernel = CreateKernel();
                kernel.GetAll<IExample>().ForEach(e => e.Run());
            }
            catch (Exception exception)
            {
                Console.WriteLine("\n{0}", exception);
            }
            finally
            {
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Creates and configures an instance of <see cref="IKernel"/>.
        /// </summary>
        /// <returns>An instance of <see cref="IKernel"/>.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind(scanner =>
                scanner.FromAssemblyContaining<IExample>()
                       .SelectAllClasses()
                       .InheritedFrom<IExample>()
                       .BindAllInterfaces());

            return kernel;
        }
    }
}
