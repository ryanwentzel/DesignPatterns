using System;

namespace DesignPatterns.Core.Strategy
{
    public sealed class StrategyExample1 : Example
    {
        public StrategyExample1()
            : base("Strategy", "Various hashing utilities implementated as strategies")
        {
        }

        protected override void ExecuteExample()
        {
            string input = "This is a string to hash.";
            Console.WriteLine("String to hash: {0}\n", input);

            ScanFor<IHasher>().ForEach(type => 
            {
                var hasher = Activator.CreateInstance(type) as IHasher;
                if (hasher != null)
                {
                    Console.WriteLine("{0}: {1}", hasher.GetType().Name, HashUtil.Hash(input, hasher));
                }
            });
        }
    }
}
