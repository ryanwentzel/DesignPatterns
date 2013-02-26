using System;

namespace DesignPatterns.Core.State
{
    public sealed class StateExample1 : Example
    {
        public StateExample1()
            : base("State", "State Pattern illustrated by an Account.")
        {
            
        }

        protected override void ExecuteExample()
        {
            Account account = new Account();

            account.Deposit(500m);
            account.Deposit(300m);
            account.Deposit(550m);

            account.PayInterest();

            account.Withdraw(2000m);
            account.Withdraw(1100m);
        }
    }
}
