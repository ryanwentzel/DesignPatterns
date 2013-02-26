
namespace DesignPatterns.Core.State
{
    public interface IState
    {
        Account Account { get; }

        decimal Balance { get; }

        void Deposit(decimal amount);

        void Withdraw(decimal amount);

        void PayInterest();
    }
}
