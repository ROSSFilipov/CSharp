using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyHierarchy.Interfaces;
using System.Text.RegularExpressions;

namespace CompanyHierarchy.Employees.RegularEmployee
{
    public class Project : IProject
    {
        private const string BASE_PROJECT_NAME = "Unspecified project";
        private const string BASE_DETAILS = "No details";
        private const string BASE_STATE = "Open";

        private string projectName;

        private DateTime startDate;

        private string details;

        private string state;

        public Project(string projectName, DateTime date, string details, string state)
        {
            this.ProjectName = projectName;
            this.ProjectStartDate = date;
            this.Details = details;
            this.State = state;
        }

        public Project()
            : this(BASE_PROJECT_NAME, DateTime.Now, BASE_DETAILS, BASE_STATE)
        {
            
        }

        public string ProjectName
        {
            get
            {
                return this.projectName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.projectName = value;
            }
        }

        public DateTime ProjectStartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                this.startDate = value;
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }
            set
            {
                this.details = value;
            }
        }

        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                Regex statePattern = new Regex("open|closed", RegexOptions.IgnoreCase);
                if (value != "Open" && value != "Closed")
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.state = value;
            }
        }

        public void CloseProject()
        {
            this.State = "Closed";
        }

        public override string ToString()
        {
            return String.Format("\tProject - {0}, Date: [{1}], Details: [{2}], State - [{3}].", 
                this.ProjectName, this.ProjectStartDate, this.Details, this.State);
        }
    }
}
