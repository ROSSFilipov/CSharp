using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy.Employees.RegularEmployee
{
    public class Developer : Employee
    {
        public HashSet<Project> projectSet { get; set; }

        public Developer(string firstName, string lastName, long id, string department, decimal salary, HashSet<Project> projectSet) : base(firstName, lastName, id, department, salary)
        {
            this.projectSet = new HashSet<Project>(projectSet);
        }

        public Developer()
            : base()
        {
            this.projectSet = new HashSet<Project>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("[{0} - {1}, {2}, {3}]", this.GetType().Name, this.FirstName, this.LastName, this.ID));
            foreach (Project currentProject in this.projectSet)
            {
                sb.AppendLine(currentProject.ToString());
            }
            return sb.ToString();
        }
    }
}
