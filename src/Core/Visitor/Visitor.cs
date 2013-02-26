using System;

namespace DesignPatterns.Core.Visitor
{
    /// <summary>
    /// Implementation of the <see cref="IVisitor"/> interface.
    /// </summary>
    public sealed class Visitor : IVisitor
    {
        public void Process(TestFixture fixture)
        {
            Console.WriteLine("Processing {0}", fixture.Name);
            fixture.ChildLeaves.ForEach(leaf => leaf.AcceptVisitor(this));
        }

        public void Process(Test test)
        {
            Console.WriteLine("\tProcessing {0}", test.Name);
            test.ChildLeaves.ForEach(leaf => leaf.AcceptVisitor(this));
        }
    }
}
