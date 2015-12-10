using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.ControlCenter.Exceptions
{
    public static class CustomMessages
    {
        public const string InvalidNameMessage = "Invalid name. Name cannot be empty.";
        public const string InvalidSalaryMessage = "Invalid salary. Salary cannot be negative.";
        public const string InvalidEmployeeTypeMesage = "Unknown employee type";
        public const string CompanyNullMessage = "The given company does not exists.";
        public const string DepartmentNullMessage = "The given department does not exists.";
    }
}
