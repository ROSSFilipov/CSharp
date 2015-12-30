using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SingingCats
{
    static void Main(string[] args)
    {
        string[] catsInput = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        string[] songsInput = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

        int cats = int.Parse(catsInput[0]);
        int songs = int.Parse(songsInput[0]);

        var collection = new Dictionary<int, List<int>>();

        TakeInput(collection);

        LinkedList<int> catCollection = new LinkedList<int>();

        for (int i = 1; i <= cats; i++)
        {
            catCollection.AddLast(i);
        }

        var sortedCollection = collection.OrderByDescending(x => x.Value.Count);

        int songsNeededCount = 0;
        foreach (KeyValuePair<int, List<int>> item in sortedCollection)
        {
            for (int i = 0; i < item.Value.Count; i++)
            {
                LinkedListNode<int> currentCat = catCollection.Find(item.Value[i]);
                if (currentCat != null)
                {
                    catCollection.Remove(currentCat);
                }
            }

            if (catCollection.Count == 0)
            {
                songsNeededCount++;
                break;
            }
            else
            {
                songsNeededCount++;
            }
        }

        if (catCollection.Count != 0)
        {
            Console.WriteLine("No concert!");
        }
        else
        {
            Console.WriteLine(songsNeededCount);
        }
    }

    private static void TakeInput(Dictionary<int, List<int>> collection)
    {
        while (true)
        {
            string[] currentLine = Console.ReadLine().Trim().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            if (currentLine[0] == "Mew!")
            {
                break;
            }

            int catNumber = int.Parse(currentLine[1]);
            int songNumber = int.Parse(currentLine[4]);

            if (!collection.ContainsKey(songNumber))
            {
                collection.Add(songNumber, new List<int>());
            }

            collection[songNumber].Add(catNumber);
        }
    }
}

