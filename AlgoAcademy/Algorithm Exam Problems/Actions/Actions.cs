using System;
using System.Collections.Generic;
using System.Linq;

class Actions
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int numberOfNodes = int.Parse(input[0]);
        int numberOfActions = int.Parse(input[1]);

        TopSortSolution(numberOfNodes, numberOfActions);
    }

    /// <summary>
    /// We use a sorted set as the problem requires the first lexicographically ordered solution.
    /// </summary>
    private static void TopSortSolution(int numberOfNodes, int numberOfActions)
    {
        int[] incomingConnections = new int[numberOfNodes];
        HashSet<int>[] graph = new HashSet<int>[numberOfNodes];
        graph[0] = new HashSet<int>();
        for (int i = 1; i < numberOfNodes; i++)
        {
            graph[i] = new HashSet<int>();
        }

        ReadActionData(graph, incomingConnections, numberOfActions);

        SortedSet<int> nodeSet = new SortedSet<int>();
        for (int i = 0; i < numberOfNodes; i++)
        {
            if (incomingConnections[i] == 0)
            {
                nodeSet.Add(i);
            }
        }

        while (nodeSet.Count > 0)
        {
            int currentNode = nodeSet.ElementAt(0);
            nodeSet.Remove(currentNode);
            Console.WriteLine(currentNode);
            foreach (int child in graph[currentNode])
            {
                incomingConnections[child]--;
                if (incomingConnections[child] == 0)
                {
                    nodeSet.Add(child);
                }
            }
        }
    }

    private static void ReadActionData(HashSet<int>[] graph, int[] incomingConnections, int numberOfActions)
    {
        for (int i = 0; i < numberOfActions; i++)
        {
            int[] currentEdge = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            graph[currentEdge[0]].Add(currentEdge[1]);
            incomingConnections[currentEdge[1]]++;
        }
    }
}

