
namespace DesignPatterns.Core.Decorator
{
    public sealed class EnvironmentImpl : IEnvironment
    {
        public EnvironmentImpl(User currentUser)
        {
            Ensure.ArgumentNotNull(currentUser, "currentUser");

            User = currentUser;
        }

        public User User { get; private set; }
    }
}
