using System;
using System.Collections.Generic;
using System.Linq;

class MessageSharing
{
    private static Dictionary<string, int> nameIndex = new Dictionary<string, int>();
    private static HashSet<int>[] graph;
    private static int stepCounter = 0;
    private static int visitedPeople = 0;
    private static HashSet<int> currentNames;
    private static bool[] visited;
    static void Main(string[] args)
    {
        string[] names = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        int size = names.Length - 1;
        for (int i = 1; i < size + 1; i++)
        {
            nameIndex.Add(names[i], i - 1);
        }

        AssembleGraph(size);
        string[] startingNames = Console.ReadLine()
            .Split(new char[] { ' ', ',', ':' }, StringSplitOptions.RemoveEmptyEntries);

        visited = new bool[size];

        BFS(graph, startingNames);

        PrintOutput(names, size);
    }

    private static void AssembleGraph(int size)
    {
        graph = new HashSet<int>[size];
        for (int i = 0; i < size; i++)
        {
            graph[i] = new HashSet<int>();
        }

        string[] connections = Console.ReadLine()
            .Split(new char[] { ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 1; i < connections.Length; i++)
        {
            string[] currentConnection = connections[i]
                .Split(new char[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            graph[nameIndex[currentConnection[0]]].Add(nameIndex[currentConnection[1]]);
            graph[nameIndex[currentConnection[1]]].Add(nameIndex[currentConnection[0]]);
        }
    }

    private static void BFS(HashSet<int>[] graph, string[] startingNames)
    {
        Queue<int> queue = new Queue<int>();
        for (int i = 1; i < startingNames.Length; i++)
        {
            queue.Enqueue(nameIndex[startingNames[i]]);
            visited[nameIndex[startingNames[i]]] = true;
            visitedPeople++;
        }

        while (queue.Count > 0)
        {
            currentNames = new HashSet<int>();
            while (queue.Count > 0)
            {
                currentNames.Add(queue.Dequeue());
            }

            bool found = false;
            foreach (int name in currentNames)
            {
                foreach (int friend in graph[name])
                {
                    if (!visited[friend])
                    {
                        visited[friend] = true;
                        visitedPeople++;
                        queue.Enqueue(friend);
                        found = true;
                    }
                }
            }

            if (found)
            {
                stepCounter++;
            }
        }
    }

    private static void PrintOutput(string[] names, int size)
    {
        if (visitedPeople != size)
        {
            List<string> nonVisitedPeople = new List<string>();
            for (int i = 0; i < size; i++)
            {
                if (!visited[i])
                {
                    nonVisitedPeople.Add(nameIndex.First(x => x.Value == i).Key);
                }
            }

            nonVisitedPeople.Sort();
            Console.WriteLine("Cannot reach: {0}", string.Join(", ", nonVisitedPeople));
        }
        else
        {
            List<string> lastNames = new List<string>();
            foreach (int name in currentNames)
            {
                lastNames.Add(nameIndex.First(x => x.Value == name).Key);
            }

            lastNames.Sort();
            Console.WriteLine("All people reached in {0} steps", stepCounter);
            Console.WriteLine("People at last step: {0}", string.Join(", ", lastNames));
        }
    }
}

