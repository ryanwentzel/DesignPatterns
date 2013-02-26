// From examples at http://codebetter.com/jeremymiller/2007/10/31/be-not-afraid-of-the-visitor-the-big-bad-composite-or-their-little-friend-double-dispatch/

using System.Collections.Generic;

namespace DesignPatterns.Core.Visitor
{
    public interface ILeaf
    {
        IEnumerable<ILeaf> ChildLeaves { get; }
        void AcceptVisitor(IVisitor visitor);
    }
}
