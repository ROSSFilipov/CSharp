using BankOfKK.Accounts;
using BankOfKK.Customers;
using BankOfKK.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKK
{
    class BankOfKK
    {
        static void Main(string[] args)
        {
            List<IAccount> accountData = new List<IAccount>();
            accountData.Add(new LoanAccount(5678.234m, 12.4m, new CorporateCustomer()));
            accountData.Add(new MortgageAccount(7786m, 5.6m, new IndividualCustomer()));
            accountData.Add(new DepositAccount(10453.888m, 14.2m, new IndividualCustomer()));

            foreach (IAccount currentAccount in accountData)
            {
                Console.WriteLine(currentAccount.CalculateInterest(2));
            }
        }
    }
}
