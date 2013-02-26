
namespace DesignPatterns.Core.NullObject
{
    public sealed class NullObjectExample1 : Example
    {
        public NullObjectExample1()
            : base("Null Object", "Using a NullLogger")
        {
            
        }

        protected override void ExecuteExample()
        {
            var obj = new ClassThatUsesLogger(new Logger());
            obj.UseLogger();
            obj.UseLogger();

            obj = new ClassThatUsesLogger(new NullLogger());
            obj.UseLogger();
            obj.UseLogger();
        }
    }
}
