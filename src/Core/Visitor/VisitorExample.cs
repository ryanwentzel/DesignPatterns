using System.Collections.Generic;

namespace DesignPatterns.Core.Visitor
{
    public sealed class VisitorExample : Example
    {
        public VisitorExample()
            : base("Visitor", "Visiting Test Fixture and child Tests")
        {
        }

        protected override void ExecuteExample()
        {
            IVisitor visitor = new Visitor();
            var fixture = new TestFixture("Test Fixture 1", new List<Test> { new Test("Test 1"), new Test("Test 2"), new Test("Test 3") });
            fixture.AcceptVisitor(visitor);
        }
    }
}
