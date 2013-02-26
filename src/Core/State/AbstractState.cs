// Based on examples at http://www.dofactory.com/Patterns/PatternState.aspx

namespace DesignPatterns.Core.State
{
    public abstract class AbstractState : IState
    {
        protected decimal Interest { get; set; }

        protected decimal LowerLimit { get; set; }

        protected decimal UpperLimit { get; set; }

        public decimal Balance { get; protected set; }

        public Account Account { get; protected set; }

        protected AbstractState(IState state)
        {
            Ensure.ArgumentNotNull(state, "state");

            Balance = state.Balance;
            Account = state.Account;
        }

        protected AbstractState(decimal balance, Account account)
        {
            Ensure.ArgumentNotNull(account, "account");

            Balance = balance;
            Account = account;
        }

        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
            CheckState();
        }

        public virtual void Withdraw(decimal amount)
        {
            Balance -= amount;
            CheckState();
        }

        public virtual void PayInterest()
        {
            Balance += Interest * Balance;
            CheckState();
        }

        protected abstract void CheckState();
    }
}
