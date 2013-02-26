
namespace DesignPatterns.Core.State
{
    public sealed class GoldState : AbstractState
    {
        public GoldState(IState state)
            : base(state)
        {
            Interest = 0.05m;
            LowerLimit = 1000m;
            UpperLimit = 10000000m;
        }

        public override void PayInterest()
        {
            Balance += Interest * Balance;
            CheckState();
        }

        protected override void CheckState()
        {
            if (Balance < decimal.Zero)
            {
                Account.ChangeState(new RedState(this));
            }
            else if (Balance < LowerLimit)
            {
                Account.ChangeState(new SilverState(this));
            }
        }
    }
}
