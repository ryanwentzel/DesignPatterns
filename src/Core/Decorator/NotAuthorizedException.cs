using System;

namespace DesignPatterns.Core.Decorator
{
    [Serializable]
    public sealed class NotAuthorizedException : Exception
    {
        public NotAuthorizedException()
        {
        }

        public NotAuthorizedException(string message)
            : base(message)
        {
        }

        public NotAuthorizedException(SecurityLevel requiredLevel)
            : base(string.Format("The current user requires the {0} security level to perform the operation.", requiredLevel))
        {
        }
    }
}
