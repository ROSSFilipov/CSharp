using BankOfKK.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKK.Accounts
{
    public abstract class Account : IAccount
    {
        private decimal balance;
        private decimal interestRate;
        private ICustomer customer;

        protected Account(decimal balance, decimal interestRate, ICustomer customer)
        {
            this.Balance = balance;
            this.InterestRate = interestRate;
            this.Customer = customer;
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest rate cannot be negative!");
                }

                this.interestRate = value;
            }
        }

        public ICustomer Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                this.customer = value;
            }
        }


        public abstract decimal CalculateInterest(int months);
    }
}
