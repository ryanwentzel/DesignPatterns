
namespace DesignPatterns.Core.State
{
    public sealed class SilverState : AbstractState
    {
        public SilverState(IState state)
            : base(state)
        {
            Initialize();
        }

        public SilverState(decimal balance, Account account)
            : base(balance, account)
        {
            Initialize();
        }

        private void Initialize()
        {
            Interest = decimal.Zero;
            LowerLimit = decimal.Zero;
            UpperLimit = 1000m;
        }

        protected override void CheckState()
        {
            if (Balance < LowerLimit)
            {
                Account.ChangeState(new RedState(this));
            }
            else if (Balance > UpperLimit)
            {
                Account.ChangeState(new GoldState(this));
            }
        }
    }
}
