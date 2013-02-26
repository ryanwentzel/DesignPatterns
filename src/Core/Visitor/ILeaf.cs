using System.Collections.Generic;

namespace DesignPatterns.Core.Visitor
{
    public interface ILeaf
    {
        IEnumerable<ILeaf> ChildLeaves { get; }
        void AcceptVisitor(IVisitor visitor);
    }
}
