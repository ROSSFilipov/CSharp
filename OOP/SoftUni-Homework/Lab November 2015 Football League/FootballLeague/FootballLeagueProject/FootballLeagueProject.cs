using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeagueProject
{
    class FootballLeagueProject
    {
        static void Main(string[] args)
        {
            while (true)
            {
                String currentLine = Console.ReadLine();

                if (currentLine.Equals("End"))
                {
                    break;
                }

                try
                {
                    LeagueManager.HandleInput(currentLine);
                }
                catch (InvalidOperationException ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }
        }
    }
}
