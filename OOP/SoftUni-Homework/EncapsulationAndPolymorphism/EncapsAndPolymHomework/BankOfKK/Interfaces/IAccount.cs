using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKK.Interfaces
{
    interface IAccount
    {
        decimal Balance { get; set; }
        decimal InterestRate { get; set; }
        decimal CalculateInterest(int months);
    }
}
