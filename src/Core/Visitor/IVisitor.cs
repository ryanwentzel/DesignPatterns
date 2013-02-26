
namespace DesignPatterns.Core.Visitor
{
    /// <summary>
    /// Defines a visitor
    /// </summary>
    public interface IVisitor
    {
        void Process(TestFixture fixture);
        void Process(Test test);
    }
}
