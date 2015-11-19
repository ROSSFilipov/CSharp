using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentWorker
{
    public class Worker : Human
    {
        private const decimal BASE_SALARY = 200m;
        private const int BASE_HOURS_DAY = 8;

        private decimal weekSalary;

        private int workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, int workHours) 
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHours;
        }

        public Worker()
            : base()
        {
            this.WeekSalary = BASE_SALARY;
            this.WorkHoursPerDay = BASE_HOURS_DAY;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary must be non-negative.");
                }

                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Work hours per day must be non-negative.");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal moneyPerHour = (this.WeekSalary / 5m) / this.WorkHoursPerDay;
            return moneyPerHour;
        }
    }
}
