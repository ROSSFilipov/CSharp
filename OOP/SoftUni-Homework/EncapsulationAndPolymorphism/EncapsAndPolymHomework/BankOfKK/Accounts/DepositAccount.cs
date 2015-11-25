using BankOfKK.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfKK.Customers;

namespace BankOfKK.Accounts
{
    public class DepositAccount : Account, IDeposit, IWithdraw
    {
        public DepositAccount(decimal balance, decimal interestRate, ICustomer customer)
            : base(balance, interestRate, customer)
        {

        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance >= 0 && this.Balance < 1000)
            {
                return 0;
            }
            else
            {
                decimal result = this.Balance * (1 + this.InterestRate * months);
                return result;
            }
        }
    }
}
