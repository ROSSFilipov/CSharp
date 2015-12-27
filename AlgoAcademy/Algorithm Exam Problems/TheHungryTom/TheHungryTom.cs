using System;
using System.Collections.Generic;
using System.Linq;

class TheHungryTom
{
    private static List<int>[] graph;
    private static LinkedList<int> path = new LinkedList<int>();
    private static bool[] visited;
    private static List<List<int>> pathsCollection = new List<List<int>>();
    static void Main(string[] args)
    {
        int numberOfNodes = int.Parse(Console.ReadLine());
        int numberOfEdges = int.Parse(Console.ReadLine());
        visited = new bool[numberOfNodes + 1];

        AssembleGraph(numberOfNodes, numberOfEdges);

        DFS(1, 1, numberOfNodes);

        if (pathsCollection.Count == 0)
        {
            Console.WriteLine(-1);
        }
        else
        {
            pathsCollection.Sort((x, y) =>
                {
                    for (int i = 0; i < x.Count; i++)
                    {
                        if (x[i] < y[i])
                        {
                            return -1;
                        }
                        else if (x[i] > y[i])
                        {
                            return 1;
                        }
                    }
                    return 0;
                }
                );

            Console.WriteLine(pathsCollection.Count);
            foreach (List<int> currentPath in pathsCollection)
            {
                Console.WriteLine(string.Join(" ", currentPath));
            }
        }
    }

    private static void AssembleGraph(int numberOfNodes, int numberOfEdges)
    {
        graph = new List<int>[numberOfNodes + 1];
        for (int i = 0; i < numberOfNodes + 1; i++)
        {
            graph[i] = new List<int>();
        }

        for (int i = 0; i < numberOfEdges; i++)
        {
            int[] currentEdge = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            graph[currentEdge[0]].Add(currentEdge[1]);
            graph[currentEdge[1]].Add(currentEdge[0]);
        }
    }

    private static void DFS(int currentNode, int startingNode, int numberOfNodes)
    {
        if (currentNode == startingNode && visited[startingNode] && path.Count == numberOfNodes)
        {
            path.AddLast(startingNode);
            pathsCollection.Add(new List<int>(path));
            path.RemoveLast();
            return;
        }

        if (visited[currentNode])
        {
            return;
        }

        visited[currentNode] = true;
        path.AddLast(currentNode);

        foreach (int childNode in graph[currentNode])
        {
            DFS(childNode, startingNode, numberOfNodes);
        }

        path.RemoveLast();
        visited[currentNode] = false;
    }
}

