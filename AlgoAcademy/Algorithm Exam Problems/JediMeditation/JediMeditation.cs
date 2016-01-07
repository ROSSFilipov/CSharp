using System;
using System.Collections.Generic;
using System.Linq;

class JediMeditation
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] jedi = Console.ReadLine().Split();

        List<string> jediMaster = new List<string>();
        List<string> jediKnight = new List<string>();
        List<string> jediPadawan = new List<string>();
        for (int i = 0; i < n; i++)
        {
            if (jedi[i][0] == 'm')
            {
                jediMaster.Add(jedi[i]);
            }
            else if (jedi[i][0] == 'k')
            {
                jediKnight.Add(jedi[i]);
            }
            else
            {
                jediPadawan.Add(jedi[i]);
            }
        }

        Console.WriteLine("{0} {1} {2}",
            string.Join(" ", jediMaster),
            string.Join(" ", jediKnight),
            string.Join(" ", jediPadawan));
    }
}

