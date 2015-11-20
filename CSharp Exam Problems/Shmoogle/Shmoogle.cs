using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shmoogle
{
    class Shmoogle
    {
        static void Main(string[] args)
        {
            List<string> doublesCollection = new List<string>();
            List<string> intCollection = new List<string>();

            while (true)
            {
                string currentLine = Console.ReadLine();

                if (currentLine == "//END_OF_CODE")
                {
                    break;
                }

                MatchCollection currentDoubles = Regex.Matches(currentLine, "double\\s([a-z][a-zA-Z]*)");
                MatchCollection currentInts = Regex.Matches(currentLine, "int\\s([a-z][a-zA-Z]*)");

                foreach (Match item in currentDoubles)
                {
                    doublesCollection.Add(item.Groups[1].Value);
                }

                foreach (Match item in currentInts)
                {
                    intCollection.Add(item.Groups[1].Value);
                }
            }

            doublesCollection.Sort();
            intCollection.Sort();

            Console.WriteLine("Doubles: {0}", doublesCollection.Count > 0 ? string.Join(", ", doublesCollection) : "None");

            Console.WriteLine("Ints: {0}", intCollection.Count > 0 ? string.Join(", ", intCollection) : "None");
        }
    }
}
