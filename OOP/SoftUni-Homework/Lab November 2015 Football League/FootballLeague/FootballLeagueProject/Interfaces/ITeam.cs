using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballLeagueProject.Models;

namespace FootballLeagueProject.Interfaces
{
    public interface ITeam
    {
        string Name { get; set; }
        string NickName { get; set; }
        DateTime DateFounded { get; set; }

        void AddPlayer(Player currentPlayer);
    }
}
