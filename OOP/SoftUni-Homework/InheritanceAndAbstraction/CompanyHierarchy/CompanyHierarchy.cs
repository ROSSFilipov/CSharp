using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyHierarchy.Employees;
using CompanyHierarchy.Employees.RegularEmployee;

namespace CompanyHierarchy
{
    class CompanyHierarchy
    {
        static void Main(string[] args)
        {
            List<Person> personData = new List<Person>();
            Manager one = new Manager();
            one.EmployeSet.Add(new Developer());
            SalesEmployee two = new SalesEmployee();
            two.SaleSet.Add(new Sale());
            two.SaleSet.Add(new Sale());
            Developer three = new Developer();
            three.projectSet.Add(new Project());
            three.projectSet.Add(new Project());

            personData.Add(one);
            personData.Add(two);
            personData.Add(three);

            foreach (Person currentPerson in personData)
            {
                Console.WriteLine(currentPerson);
            }
        }
    }
}
