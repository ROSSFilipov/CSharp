using FootballLeagueProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeagueProject
{
    public static class LeagueManager
    {
        public static void HandleInput(string currentLine)
        {
            var currentInfo = currentLine
                .Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            switch (currentInfo[0])
            {
                case "AddTeam": 
                    AddTeam(currentInfo[1], currentInfo[2], DateTime.Parse(currentInfo[3]));
                    break;
                case "AddMatch": 
                    AddMatch(int.Parse(currentInfo[1]), currentInfo[2], currentInfo[3], int.Parse(currentInfo[4]), int.Parse(currentInfo[5]));
                    break;
                case "AddPlayerToTeam":
                    AddPlayerToTeam(currentInfo[1], currentInfo[2], DateTime.Parse(currentInfo[3]), decimal.Parse(currentInfo[4]), currentInfo[5]);
                    break;
                case "ListTeams":
                    ListTeams();
                    break;
                case "ListMatches":
                    ListMatches();
                    break;
                default:
                    break;
            }
        }

        private static void AddTeam(string teamName, string teamNickName, DateTime teamFoundationDate)
        {
            Team currentTeam = new Team(teamName, teamNickName, teamFoundationDate);

            League.AddTeam(currentTeam);

            Console.WriteLine("Team successfully added!");
        }

        private static void AddMatch(int currentID, string homeTeamName, string awayTeamName, int homeTeamScore, int awayTeamScore)
        {
            Team currentHomeTeam = League.Teams.FirstOrDefault(x => x.Name.Equals(homeTeamName));
            Team currentAwayTeam = League.Teams.FirstOrDefault(x => x.Name.Equals(awayTeamName));

            if (currentHomeTeam == null)
            {
                throw new InvalidOperationException("Home team does not exist in the league!");
            }

            if (currentAwayTeam == null)
            {
                throw new InvalidOperationException("Away team does not exist in the league!");
            }

            Match currentMatch = new Match(currentID, currentHomeTeam, currentAwayTeam, new Score(homeTeamScore, awayTeamScore));

            League.AddMatch(currentMatch);

            Console.WriteLine("Match successfully added!");
        }

        private static void AddPlayerToTeam(string playerFirstName, string playerLastName, DateTime playerDOB, decimal playerSalary, string playerTeamName)
        {
            Player currentPlayer = new Player(playerFirstName, playerLastName, playerDOB, playerSalary);
            Team currentTeam = League.Teams.FirstOrDefault(x => x.Name.Equals(playerTeamName));

            if (currentTeam == null)
            {
                throw new InvalidOperationException("Team does not exist in the league!");
            }

            currentPlayer.Team = currentTeam;
            currentTeam.AddPlayer(currentPlayer);
        }

        private static void ListTeams()
        {
            foreach (Team currentTeam in League.Teams)
            {
                Console.WriteLine(currentTeam);
                foreach (Player currentPlayer in currentTeam.Players)
                {
                    Console.WriteLine(currentPlayer);
                }
            }
        }

        private static void ListMatches()
        {
            foreach (Match currentMatch in League.Matches)
            {
                Console.WriteLine(currentMatch);
            }
        }
    }
}
