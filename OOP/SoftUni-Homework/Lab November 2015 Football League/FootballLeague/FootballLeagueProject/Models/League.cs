using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeagueProject.Models
{
    public static class League
    {
        private static List<Team> teams = new List<Team>();
        private static List<Match> matches = new List<Match>();

        public static IEnumerable<Team> Teams
        {
            get
            {
                return teams;
            }
        }

        public static IEnumerable<Match> Matches
        {
            get
            {
                return matches;
            }
        }

        public static void AddMatch(Match currentMatch)
        {
            if (MatchExists(currentMatch))
            {
                throw new InvalidOperationException("Match already exists!");
            }

            matches.Add(currentMatch);
        }

        private static bool MatchExists(Match currentMatch)
        {
            bool matchExists = Matches.Any(x => x.ID == currentMatch.ID);
            return matchExists;
        }

        public static void AddTeam(Team currentTeam)
        {
            if (TeamExists(currentTeam))
            {
                throw new InvalidOperationException("Team already exists in the league!");
            }

            teams.Add(currentTeam);
        }

        private static bool TeamExists(Team currentTeam)
        {
            bool teamExists = Teams.Any(x => x.Name.Equals(currentTeam.Name));
            return teamExists;
        }
    }
}
