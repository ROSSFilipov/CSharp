using System;
using System.Collections.Generic;
using System.Linq;

class GarbageCollection
{
    static void Main(string[] args)
    {
        int numberOfTurns = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfTurns; i++)
        {
            string[] currentLine = Console.ReadLine()
                .Split();

            string name = currentLine[0];
            int numberOfNodes = int.Parse(currentLine[1]);
            int numberOfEdges = int.Parse(currentLine[2]);

            ExecuteSolution(name, numberOfNodes, numberOfEdges);
        }
    }

    private static void ExecuteSolution(string name, int numberOfNodes, int numberOfEdges)
    {
        List<int>[] graph = new List<int>[numberOfNodes + 1];
        for (int i = 1; i < numberOfNodes + 1; i++)
        {
            graph[i] = new List<int>();
        }

        ReadInput(graph, numberOfEdges);

        //DFSBasedSolution(graph, name, numberOfNodes, numberOfEdges);

        FastSolution(graph, name, numberOfNodes, numberOfEdges);
    }

    /// <summary>
    /// The fast solution here is based on the Euler cycle/path criteria. In case there are no
    /// nodes in the undirected graph with odd number of outgoing connections there is an Euler
    /// cycle. In case there are exactly two nodes in the graph with odd number of outgoing
    /// connections - there is an Euler path.
    /// </summary>
    private static void FastSolution(List<int>[] graph, string name, int numberOfNodes, int numberOfEdges)
    {
        int oddNodes = 0;
        for (int i = 1; i < numberOfNodes + 1; i++)
        {
            if (graph[i].Count % 2 != 0)
            {
                oddNodes++;
                if (oddNodes > 2)
                {
                    break;
                }
            }
        }

        if (oddNodes == 0)
        {
            Console.WriteLine("{0} Wolf", name);
        }
        else if (oddNodes == 2)
        {
            Console.WriteLine("{0} Titan", name);
        }
        else
        {
            Console.WriteLine("{0} Dirty", name);
        }
    }

    private static void DFSBasedSolution(List<int>[] graph, string name, int numberOfNodes, int numberOfEdges)
    {
        bool[,] visitedEdge = new bool[numberOfNodes + 1, numberOfNodes + 1];

        int wolf = 0;
        int titan = 0;

        int edgesHandled = 0;
        DFS(1, 1, graph, visitedEdge, ref wolf, ref titan, numberOfEdges, ref edgesHandled);

        if (wolf == 1)
        {
            Console.WriteLine("{0} Wolf", name);
        }
        else if (titan == 1)
        {
            Console.WriteLine("{0} Titan", name);
        }
        else
        {
            Console.WriteLine("{0} Dirty", name);
        }
    }

    private static void DFS(int currentNode, int startingNode, List<int>[] graph, bool[,] visitedEdge, ref int wolf, ref int titan, int numberOfEdges, ref int edgesHandled)
    {
        if (edgesHandled == numberOfEdges && wolf == 0)
        {
            if (currentNode == startingNode)
            {
                wolf = 1;
                titan = 0;
                return;
            }
            else
            {
                titan = 1;
                wolf = 0;
                return;
            }
        }

        foreach (int connectedNode in graph[currentNode])
        {
            if (wolf == 1)
            {
                break;
            }
            else if (!visitedEdge[currentNode, connectedNode])
            {
                visitedEdge[currentNode, connectedNode] = true;
                visitedEdge[connectedNode, currentNode] = true;
                edgesHandled++;
                DFS(connectedNode, startingNode, graph, visitedEdge, ref wolf, ref titan, numberOfEdges, ref edgesHandled);
                edgesHandled--;
                visitedEdge[currentNode, connectedNode] = false;
                visitedEdge[connectedNode, currentNode] = false;
            }
        }
    }

    private static void ReadInput(List<int>[] graph, int numberOfEdges)
    {
        for (int i = 0; i < numberOfEdges; i++)
        {
            string[] currentLine = Console.ReadLine().Split();
            graph[int.Parse(currentLine[0])].Add(int.Parse(currentLine[1]));
            graph[int.Parse(currentLine[1])].Add(int.Parse(currentLine[0]));
        }
    }
}

