using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy.Employees.RegularEmployee
{
    public class SalesEmployee : Employee
    {
        public HashSet<Sale> SaleSet { get; set; }

        public SalesEmployee(string firstName, string lastName, long id, string department, decimal salary) 
            : base(firstName, lastName, id, department, salary)
        {
            this.SaleSet = new HashSet<Sale>();
        }

        public SalesEmployee() 
            : base()
        {
            this.SaleSet = new HashSet<Sale>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("[{0} - {1}, {2}, {3}]", this.GetType().Name, this.FirstName, this.LastName, this.ID));
            foreach (Sale currentSale in this.SaleSet)
            {
                sb.AppendLine(currentSale.ToString());
            }
            return sb.ToString();
        }
    }
}
