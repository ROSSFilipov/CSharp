using System;
using System.Collections.Generic;
using System.Linq;

class BojiGoal
{
    static void Main(string[] args)
    {
        int numberOfNodes = int.Parse(Console.ReadLine());
        int startingNode = int.Parse(Console.ReadLine());
        HashSet<int>[] graph = new HashSet<int>[numberOfNodes + 1];
        for (int i = 1; i < numberOfNodes + 1; i++)
        {
            graph[i] = new HashSet<int>();
        }

        long[,] costMatrix = new long[numberOfNodes + 1, numberOfNodes + 1];
        ReadInput(graph, costMatrix);

        FindShortesPath(graph, costMatrix, numberOfNodes, startingNode);
    }

    private static void FindShortesPath(HashSet<int>[] graph, long[,] costMatrix, int numberOfNodes, int startingNode)
    {
        int visitedNodes = 0;
        long bestLength = long.MaxValue;
        long currentLength = 0;
        bool[] visited = new bool[numberOfNodes + 1];

        DFS(graph, visited, costMatrix, startingNode, startingNode, ref visitedNodes, ref bestLength, ref currentLength);

        if (bestLength != long.MaxValue)
        {
            Console.WriteLine(bestLength);
        }
        else
        {
            Console.WriteLine(0);
        }
    }

    private static void DFS(HashSet<int>[] graph, bool[] visited, long[,] costMatrix, int currentNode, int startingNode, ref int visitedNodes, ref long bestLength, ref long currentLength)
    {
        if (currentNode == startingNode && visitedNodes == graph.Length - 1)
        {
            if (currentLength < bestLength)
            {
                bestLength = currentLength;
            }

            return;
        }

        if (currentNode == startingNode && visited[startingNode])
        {
            return;
        }

        foreach (int connectedNode in graph[currentNode])
        {
            if (!visited[connectedNode])
            {
                visited[connectedNode] = true;
                visitedNodes++;
                currentLength += costMatrix[currentNode, connectedNode];
                DFS(graph, visited, costMatrix, connectedNode, startingNode, ref visitedNodes, ref bestLength, ref currentLength);
                currentLength -= costMatrix[currentNode, connectedNode];
                visitedNodes--;
                visited[connectedNode] = false;
            }
        }
    }

    private static void ReadInput(HashSet<int>[] graph, long[,] costMatrix)
    {
        while (true)
        {
            string[] currentLine = Console.ReadLine()
                .Split();
            if (currentLine[0] == "end")
            {
                break;
            }

            int firstNode = int.Parse(currentLine[0]);
            int secondNode = int.Parse(currentLine[1]);
            long cost = long.Parse(currentLine[2]);

            graph[firstNode].Add(secondNode);
            graph[secondNode].Add(firstNode);
            costMatrix[firstNode, secondNode] = cost;
            costMatrix[secondNode, firstNode] = cost;
        }
    }
}

