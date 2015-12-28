using System;
using System.Collections.Generic;
using System.Linq;

class TheTubebomber
{
    static void Main(string[] args)
    {
        int numberOfNodes = int.Parse(Console.ReadLine());
        int numberOfConnectedAreas = int.Parse(Console.ReadLine());

        HashSet<int>[] straightGraph = new HashSet<int>[numberOfNodes + 1];
        for (int i = 1; i < numberOfNodes + 1; i++)
        {
            straightGraph[i] = new HashSet<int>();
        }

        ReadGraphData(straightGraph, numberOfNodes);

        List<int> nodesData = new List<int>();
        nodesData.Add(0);

        bool[] visited = new bool[numberOfNodes + 1];
        for (int i = 1; i < numberOfNodes; i++)
        {
            CollectNodeData(straightGraph, nodesData, visited, i);
        }

        int nodeToBeRemoved = FindNodeToRemove(straightGraph, visited, nodesData, numberOfNodes, numberOfConnectedAreas);

        Console.WriteLine(nodeToBeRemoved);
    }

    private static int FindNodeToRemove(HashSet<int>[] straightGraph, bool[] visited, List<int> nodesData, int numberOfNodes, int numberOfConnectedAreas)
    {
        if (!IsStronglyConnectedGraph(straightGraph, visited, nodesData, numberOfNodes))
        {
            return -2;
        }

        int maxPieceCounter = 0;
        for (int j = 1; j < numberOfNodes + 1; j++)
        {
            visited = new bool[numberOfNodes + 1];
            visited[j] = true;
            int connectedAreasCounter = 0;
            for (int i = numberOfNodes; i >= 1; i--)
            {
                if (!visited[nodesData[i]])
                {
                    connectedAreasCounter++;
                    DFS(straightGraph, visited, nodesData[i]);
                }
            }

            if (connectedAreasCounter == numberOfConnectedAreas)
            {
                return j;
            }

            if (connectedAreasCounter > maxPieceCounter)
            {
                maxPieceCounter = connectedAreasCounter;
            }
        }

        if (maxPieceCounter == 1)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    private static bool IsStronglyConnectedGraph(HashSet<int>[] straightGraph, bool[] visited, List<int> nodesData, int numberOfNodes)
    {
        int numberOfComponents = 0;
        visited = new bool[numberOfNodes + 1];
        for (int i = numberOfNodes; i >= 1; i--)
        {
            if (!visited[nodesData[i]])
            {
                numberOfComponents++;
                if (numberOfComponents > 1)
                {
                    return false;
                }
                DFS(straightGraph, visited, nodesData[i]);
            }
        }

        return true;
    }

    private static void DFS(HashSet<int>[] straightGraph, bool[] visited, int currentNode)
    {
        if (!visited[currentNode])
        {
            visited[currentNode] = true;
            foreach (int childNode in straightGraph[currentNode])
            {
                DFS(straightGraph, visited, childNode);
            }
        }
    }

    /// <summary>
    /// Instead of a stack we are using a list to keep
    /// all nodes as we will use the list several times
    /// in the program.
    /// </summary>
    private static void CollectNodeData(HashSet<int>[] straightGraph, List<int> nodesData, bool[] visited, int currentNode)
    {
        if (!visited[currentNode])
        {
            visited[currentNode] = true;
            foreach (int childNode in straightGraph[currentNode])
            {
                CollectNodeData(straightGraph, nodesData, visited, childNode);
            }
            nodesData.Add(currentNode);
        }
    }

    private static void ReadGraphData(HashSet<int>[] straightGraph, int numberOfNodes)
    {
        for (int i = 1; i < numberOfNodes + 1; i++)
        {
            int[] currentEdge = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (int node in currentEdge)
            {
                straightGraph[i].Add(node);
            }
        }
    }
}

