
namespace DesignPatterns.Core.Decorator
{
    public class User
    {
        public string UserName { get; set; }

        public SecurityLevel Level { get; set; }
    }

    public enum SecurityLevel
    {
        User,
        Admin
    }
}
