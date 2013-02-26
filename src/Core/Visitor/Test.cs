using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Core.Visitor
{
    public sealed class Test : ILeaf, INameable
    {
        public IEnumerable<ILeaf> ChildLeaves
        {
            get { return Enumerable.Empty<ILeaf>(); }
        }

        public string Name { get; private set; }

        public Test(string name)
        {
            Name = name;
        }

        public void AcceptVisitor(IVisitor visitor)
        {
            visitor.Process(this);
        }
    }
}
