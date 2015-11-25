using BankOfKK.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfKK.Customers;

namespace BankOfKK.Accounts
{
    public class MortgageAccount : Account, IDeposit
    {
        public MortgageAccount(decimal balance, decimal interestRate, ICustomer customer)
            : base(balance, interestRate, customer)
        {

        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer is IndividualCustomer && months <= 6)
            {
                return 0;
            }

            decimal result = this.Balance * (1 + this.InterestRate * months);

            if (this.Customer is CorporateCustomer && months <= 12)
            {
                return result / 2;
            }

            return result;
        }
    }
}
