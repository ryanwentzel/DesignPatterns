using System;

namespace DesignPatterns.Core.State
{
    public sealed class RedState : AbstractState
    {
        public RedState(IState state)
            : base(state)
        {
            Interest = decimal.Zero;
            LowerLimit = -100m;
            UpperLimit = decimal.Zero;
        }

        public override void Withdraw(decimal amount)
        {
            Console.WriteLine("No funds available for withdrawl!");
        }

        protected override void CheckState()
        {
            if (Balance > UpperLimit)
            {
                Account.ChangeState(new SilverState(this));
            }
        }
    }
}
