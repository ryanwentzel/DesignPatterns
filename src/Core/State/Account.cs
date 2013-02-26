
using System;
namespace DesignPatterns.Core.State
{
    public sealed class Account
    {
        private IState State { get; set; }

        public decimal Balance
        {
            get
            {
                return State.Balance;
            }
        }

        public Account()
        {
            State = new SilverState(decimal.Zero, this);
        }

        public void Deposit(decimal amount)
        {
            State.Deposit(amount);
            Console.WriteLine("Deposited {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", Balance);
            Console.WriteLine(" Status = {0}\n", State.GetType().Name);
        }

        public void Withdraw(decimal amount)
        {
            State.Withdraw(amount);
            Console.WriteLine("Withdrew {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", Balance);
            Console.WriteLine(" Status = {0}\n", State.GetType().Name);
        }

        public void PayInterest()
        {
            State.PayInterest();
            Console.WriteLine("Interest Paid --- ");
            Console.WriteLine(" Balance = {0:C}", Balance);
            Console.WriteLine(" Status = {0}\n", State.GetType().Name);
        }

        public void ChangeState(IState newState)
        {
            State = newState;
        }
    }
}
