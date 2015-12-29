using System;
using System.Collections.Generic;
using System.Linq;

class GraphCycles
{
    private static int numberOfNodes;
    private static SortedSet<int>[] graph;
    private static bool[] visited;
    static void Main(string[] args)
    {
        numberOfNodes = int.Parse(Console.ReadLine());

        AssembleGraph();
        visited = new bool[numberOfNodes];

        FindUniqueCyclesFast();
    }

    private static void FindUniqueCyclesFast()
    {
        bool cycleFound = false;
        for (int i = 0; i < numberOfNodes; i++)
        {
            foreach (int childNode in graph[i])
            {
                if (childNode > i)
                {
                    foreach (int childNode2 in graph[childNode])
                    {
                        if (childNode2 > i && graph[childNode2].Contains(i))
                        {
                            Console.WriteLine("{{{0} -> {1} -> {2}}}", i, childNode, childNode2);
                            cycleFound = true;
                        }
                    }
                }
            }
        }

        if (!cycleFound)
        {
            Console.WriteLine("No cycles found");
        }
    }

    private static void AssembleGraph()
    {
        graph = new SortedSet<int>[numberOfNodes];
        for (int i = 0; i < numberOfNodes; i++)
        {
            graph[i] = new SortedSet<int>();
        }

        for (int i = 0; i < numberOfNodes; i++)
        {
            int[] currentLine = Console.ReadLine()
                .Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .Distinct()
                .ToArray();

            for (int j = 1; j < currentLine.Length; j++)
            {
                graph[currentLine[0]].Add(currentLine[j]);
            }
        }
    }
}

