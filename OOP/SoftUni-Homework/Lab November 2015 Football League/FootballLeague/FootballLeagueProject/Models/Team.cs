using FootballLeagueProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballLeagueProject.Models
{
    public class Team : ITeam
    {
        private const int minimumDateAllowed = 1850;
        private Regex namePattern = new Regex("[A-Z]([a-z]+){4,}");

        private string name;
        private string nickName;
        private DateTime dateFounded;
        private List<Player> players;

        public Team(string name, string nickName, DateTime dateFounded)
        {
            this.Name = name;
            this.NickName = nickName;
            this.DateFounded = dateFounded;
            this.players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || !namePattern.IsMatch(value))
                {
                    throw new ArgumentException("Invalid name! Team's name cannot be empty and must be at least 5 characters long");
                }

                this.name = value;
            }
        }

        public string NickName
        {
            get
            {
                return this.nickName;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || !namePattern.IsMatch(value))
                {
                    throw new ArgumentException("Invalid name! Team's name cannot be empty and must be at least 5 characters long");
                }

                this.nickName = value;
            }
        }

        public DateTime DateFounded
        {
            get
            {
                return this.dateFounded;
            }
            set
            {
                if (value.Year < minimumDateAllowed)
                {
                    throw new ArgumentOutOfRangeException("Team's fundation date cannot be earlier than " + minimumDateAllowed);
                }

                this.dateFounded = value;
            }
        }

        public void AddPlayer(Player currentPlayer)
        {
            if (this.PlayerExists(currentPlayer))
            {
                throw new InvalidOperationException("Player already exists in that team!");
            }

            this.players.Add(currentPlayer);
        }

        private bool PlayerExists(Player currentPlayer)
        {
            bool playerFound = this.players
                .Any(x => x.FirstName.Equals(currentPlayer.FirstName) && x.LastName.Equals(currentPlayer.LastName));

            return playerFound;
        }

        public IEnumerable<Player> Players
        {
            get
            {
                return this.players;
            }
        }

        public override string ToString()
        {
            return string.Format("Team: {0}, nickname: {1}, date founded: {2}",
                this.Name, this.NickName, this.DateFounded);
        }
    }
}
