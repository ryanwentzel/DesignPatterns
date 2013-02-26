using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Core.Visitor
{
    public sealed class TestFixture : ILeaf, INameable
    {
        private readonly List<Test> _tests;

        public string Name { get; private set; }

        public TestFixture(string name)
            : this(name, Enumerable.Empty<Test>())
        {
        }

        public TestFixture(string name, IEnumerable<Test> tests)
        {
            Name = name;
            _tests = new List<Test>(tests);
        }

        public IEnumerable<ILeaf> ChildLeaves
        {
            get { return _tests.AsReadOnly(); }
        }

        public void AcceptVisitor(IVisitor visitor)
        {
            visitor.Process(this);
        }
    }
}
