using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


public class Singer
{
    public string Name { get; set; }

    public long Sales { get; set; }

    public Singer(string name)
    {
        this.Name = name;
    }
}

public static class Extensions
{
    public static bool ContainsSinger(this List<Singer> singersList, Singer currentSinger)
    {
        bool found = false;

        for (int i = 0; i < singersList.Count; i++)
        {
            if (singersList[i].Name == currentSinger.Name)
            {
                found = true;
                break;
            }
        }

        return found;
    }

    public static int IndexOfSinger(this List<Singer> singersList, Singer currentSinger)
    {
        int index = 0;

        for (int i = 0; i < singersList.Count; i++)
        {
            if (singersList[i].Name == currentSinger.Name)
            {
                index = i;
            }
        }

        return index;
    }
}

class Unleashed
{
    static void Main(string[] args)
    {
        var collection = new Dictionary<string, List<Singer>>();

        while (true)
        {
            string currentLine = Console.ReadLine();

            if (currentLine == "End")
            {
                break;
            }

            Match concertMatch = Regex.Match(currentLine, "\\s@([a-zA-Z\\s]*?)\\s[0-9]");
            Match singerMatch = Regex.Match(currentLine, "([a-zA-Z\\s]+)@");
            Match tickets = Regex.Match(currentLine, "(\\s[0-9]+)\\s*?([0-9]+)");
            string[] inputSplit = currentLine.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            if (concertMatch.Groups.Count != 2 || singerMatch.Groups.Count != 2 || tickets.Groups.Count != 3)
            {
                continue;
            }
            else
            {
                string name = singerMatch.Groups[1].Value.Trim();
                string concert = concertMatch.Groups[1].Value.Trim();
                int ticketPrice = int.Parse(tickets.Groups[1].Value);
                int ticketCount = int.Parse(tickets.Groups[2].Value);

                long currentSale = ticketCount * ticketPrice;

                Singer currentSinger = new Singer(name);

                if (!collection.ContainsKey(concert))
                {
                    collection.Add(concert, new List<Singer>());
                }

                if (!collection[concert].ContainsSinger(currentSinger))
                {
                    collection[concert].Add(currentSinger);
                }

                int singerIndex = collection[concert].IndexOfSinger(currentSinger);
                collection[concert][singerIndex].Sales += currentSale;
            }


        }

        foreach (var item in collection)
        {
            Console.WriteLine("{0}", item.Key);
            var sortedSingers = item.Value.OrderByDescending(x => x.Sales);
            foreach (Singer currentSinger in sortedSingers)
            {
                Console.WriteLine("#  {0} -> {1}", currentSinger.Name, currentSinger.Sales);
            }
        }
    }

    private static string GetName(string[] inputSplit)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < inputSplit.Length; i++)
        {
            if (inputSplit[i][0] != '@')
            {
                sb.Append(inputSplit[i]);
            }
            else
            {
                break;
            }
        }

        return sb.ToString();
    }

    private static string GetCocertName(string p)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 1; i < p.Length; i++)
        {
            sb.Append(p[i]);
        }

        return sb.ToString();
    }
}

