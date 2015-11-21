using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeagueProject.Models
{
    public class Match
    {
        private Team homeTeam;
        private Team awayTeam;
        private Score score;
        private int id;

        public Match(int id, Team homeTeam, Team awayTeam, Score score)
        {
            this.ID = id;
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.Score = score;
        }

        public Team HomeTeam
        {
            get
            {
                return this.homeTeam;
            }
            set
            {
                this.homeTeam = value;
            }
        }

        public Team AwayTeam
        {
            get
            {
                return this.awayTeam;
            }
            set
            {
                this.awayTeam = value;
            }
        }

        public Score Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Tean's ID cannot be negative!");
                }

                this.id = value;
            }
        }

        public Team GetWinner()
        {
            if (this.IsDraw())
            {
                return null;
            }

            if (this.Score.HomeTeamGoals > this.Score.AwayTeamGoals)
            {
                return this.HomeTeam;
            }
            else
            {
                return this.AwayTeam;
            }
        }

        private bool IsDraw()
        {
            bool isDraw = this.Score.HomeTeamGoals == this.Score.AwayTeamGoals;

            return isDraw;
        }

        public override string ToString()
        {
            return string.Format("Current match: {0} - {1}. Current score: {2} - {3}",
                this.HomeTeam.Name, this.AwayTeam.Name, this.Score.HomeTeamGoals, this.Score.AwayTeamGoals);
        }
    }
}
