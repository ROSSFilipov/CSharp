using FootballLeagueProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballLeagueProject.Models
{
    public class Player : IPlayer
    {
        private const int minimumAllowedYear = 1980;
        private Regex namePattern = new Regex("[A-Z]([a-z]+){2,}");

        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private decimal salary;
        private Team team;

        public Player(string firstName, string lastName, DateTime dateOfBirth, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Salary = salary;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || !namePattern.IsMatch(value))
                {
                    throw new ArgumentException("Invalid name! Name should cannot be empty and must be at least 3 charactes long.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || !namePattern.IsMatch(value))
                {
                    throw new ArgumentException("Invalid name! Name should cannot be empty and must be at least 3 charactes long.");
                }

                this.lastName = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be negative!");
                }

                this.salary = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }
            set
            {
                if (value.Year < minimumAllowedYear)
                {
                    throw new ArgumentOutOfRangeException("Date of birth cannot be earlier than " + minimumAllowedYear);
                }

                this.dateOfBirth = value;
            }
        }

        public Team Team
        {
            get
            {
                return this.team;
            }
            set
            {
                this.team = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Player:\n{0}, {1}, DOB: {2}, Team: {3}", 
                this.FirstName, this.LastName, this.DateOfBirth, this.Team.Name);
        }
    }
}
