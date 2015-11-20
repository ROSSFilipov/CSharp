using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DragonAccounting
{
    class EmployeeGroup
    {
        public int DateHired { get; set; }

        public int Employees { get; set; }

        public decimal Salary { get; set; }

        public EmployeeGroup()
        {

        }

        public EmployeeGroup(int date, int employees, decimal salary)
        {
            this.DateHired = date;
            this.Employees = employees;
            this.Salary = salary;
        }
    }

    class DragonAccounting
    {
        static int daysCount = 0;

        static void Main(string[] args)
        {
            decimal capital = decimal.Parse(Console.ReadLine());

            var employeeList = new LinkedList<EmployeeGroup>();

            bool isBankrupt = false;

            while (true)
            {
                string[] currentLine = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                if (currentLine[0] == "END")
                {
                    break;
                }

                if (isBankrupt)
                {
                    isBankrupt = true;
                    break;
                }

                HireEmployees(employeeList, currentLine[0], currentLine[2]);

                CheckForRises(employeeList);

                GiveSalaries(employeeList, ref capital);

                FireEmployees(employeeList, currentLine[1]);

                CheckForAdditionalEvents(ref capital, currentLine);

                CheckForBankrupt(capital, ref isBankrupt);

                daysCount++;
            }

            if (isBankrupt)
            {
                Console.WriteLine("BANKRUPTCY: {0}", Math.Abs(capital));
            }
            else
            {
                int numberOfEmployees = 0;
                foreach (var currentGroup in employeeList)
                {
                    numberOfEmployees += currentGroup.Employees;
                }

                Console.WriteLine("{0} {1:F4}", numberOfEmployees, capital);
            }
        }

        private static void HireEmployees(LinkedList<EmployeeGroup> employeeList, string hired, string salary)
        {
            int hiredEmployees = int.Parse(hired);
            decimal salaryParsed = decimal.Parse(salary);
            employeeList.AddLast(new EmployeeGroup(daysCount, hiredEmployees, salaryParsed));
        }

        private static void CheckForRises(LinkedList<EmployeeGroup> employeeList)
        {
            if (daysCount >= 365)
            {
                foreach (var currentGroup in employeeList)
                {
                    if ((daysCount - currentGroup.DateHired) % 365 == 0 && (daysCount - currentGroup.DateHired) != 0)
                    {
                        decimal salaryRaise = currentGroup.Salary + (currentGroup.Salary * 6 / 100m);
                        currentGroup.Salary += salaryRaise;
                    }
                } 
            }
            else
            {
                return;
            }
        }

        private static void GiveSalaries(LinkedList<EmployeeGroup> employeeList, ref decimal capital)
        {
            if (daysCount % 30 == 0 && daysCount != 0)
            {
                foreach (var currentGroup in employeeList)
                {
                    int daysWorked = daysCount - currentGroup.DateHired;
                    capital -= currentGroup.Employees * currentGroup.Salary * (decimal)daysWorked;
                } 
            }
            else
            {
                return;
            }
        }

        private static void FireEmployees(LinkedList<EmployeeGroup> employeeList, string fired)
        {
            int firedEmployees = int.Parse(fired);

            foreach (var currentGroup in employeeList)
            {
                if (firedEmployees == 0)
                {
                    break;
                }
                else if (currentGroup.Employees > firedEmployees)
                {
                    currentGroup.Employees -= firedEmployees;
                    firedEmployees = 0;
                }
                else
                {
                    firedEmployees -= currentGroup.Employees;
                    employeeList.RemoveFirst();
                }
            }
        }

        private static void CheckForAdditionalEvents(ref decimal capital, string[] currentLine)
        {
            Regex eventsMatch = new Regex("Taxes|Product Development|Previous years deficit|Machines|Unconditional funding");

            for (int i = 3; i < currentLine.Length; i++)
            {
                string[] eventSplit = currentLine[i].Split(new char[]{ ':' }, StringSplitOptions.RemoveEmptyEntries);
                string currentEvent = eventSplit[0].Trim();
                decimal eventAmount = decimal.Parse(eventSplit[1].Trim());

                switch (currentEvent)
                {
                    case "Taxes": capital -= eventAmount;
                        break;
                    case "Product Development": capital += eventAmount;
                        break;
                    case "Previous years deficit": capital -= eventAmount;
                        break;
                    case "Machines": capital -= eventAmount;
                        break;
                    case "Unconditional funding": capital += eventAmount;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void CheckForBankrupt(decimal capital, ref bool isBankrupt)
        {
            if (capital <= 0)
            {
                isBankrupt = true;
            }
            else
            {
                return;
            }
        }
    }
}
