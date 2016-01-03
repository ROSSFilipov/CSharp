using System;
using System.Collections.Generic;
using System.Linq;

class D1skw0rld
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Trim().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        int numberOfNodes = int.Parse(input[0]);
        int numberOfEdges = int.Parse(input[1]);
        List<int>[] graph = new List<int>[numberOfNodes];
        for (int i = 0; i < numberOfNodes; i++)
        {
            graph[i] = new List<int>();
        }

        byte[,] costMatrix = new byte[numberOfNodes, numberOfNodes];
        ReadGraph(graph, costMatrix, numberOfEdges);
        FindShortestPaths(graph, costMatrix, numberOfNodes);
    }

    private static void FindShortestPaths(List<int>[] graph, byte[,] costMatrix, int numberOfNodes)
    {
        long[] bestDistances = new long[numberOfNodes];
        HashSet<int> nonVisitedNodes = new HashSet<int>();
        for (int i = 0; i < numberOfNodes; i++)
        {
            bestDistances[i] = long.MaxValue;
            nonVisitedNodes.Add(i);
        }

        bestDistances[0] = 0;
        while (true)
        {
            int currentNode = -1;
            long currentDistance = long.MaxValue;

            foreach (int node in nonVisitedNodes)
            {
                if (bestDistances[node] < currentDistance)
                {
                    currentDistance = bestDistances[node];
                    currentNode = node;
                }
            }

            if (currentNode == -1)
            {
                break;
            }

            nonVisitedNodes.Remove(currentNode);

            foreach (int connectedNode in graph[currentNode])
            {
                if (bestDistances[connectedNode] > bestDistances[currentNode] + costMatrix[currentNode, connectedNode])
                {
                    bestDistances[connectedNode] = bestDistances[currentNode] + costMatrix[currentNode, connectedNode];
                }
            }
        }

        foreach (long currentDistance in bestDistances)
        {
            if (currentDistance == long.MaxValue)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(currentDistance);
            }
        }
    }

    private static void ReadGraph(List<int>[] graph, byte[,] costMatrix, int numberOfEdges)
    {
        for (int i = 0; i < numberOfEdges; i++)
        {
            int[] currentLine = Console.ReadLine()
                .Trim()
                .Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            graph[currentLine[0]].Add(currentLine[1]);
            graph[currentLine[1]].Add(currentLine[0]);

            costMatrix[currentLine[0], currentLine[1]] = (byte)currentLine[2];
            costMatrix[currentLine[1], currentLine[0]] = (byte)currentLine[2];
        }
    }
}

