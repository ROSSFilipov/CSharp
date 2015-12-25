using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Here the solution consists of depth first search algorithm
/// combined with memoization avoiding unnecessary calculations.
/// </summary>
class Salaries
{
    private static int numberOfNodes;
    private static List<int>[] graph;
    private static long[] calculatedSalaries;
    static void Main(string[] args)
    {
        numberOfNodes = int.Parse(Console.ReadLine());
        graph = new List<int>[numberOfNodes];
        for (int i = 0; i < numberOfNodes; i++)
        {
            graph[i] = new List<int>();
        }

        AssembleGraph();

        calculatedSalaries = new long[numberOfNodes];

        for (int i = 0; i < numberOfNodes; i++)
        {
            if (calculatedSalaries[i] == 0)
            {
                calculatedSalaries[i] = DFS(i, calculatedSalaries);
            }
        }

        Console.WriteLine(calculatedSalaries.Sum());
    }

    private static long DFS(long currentNode, long[] calculatedSalaries)
    {
        if (calculatedSalaries[currentNode] != 0)
        {
            return calculatedSalaries[currentNode];
        }
        else if (graph[currentNode].Count == 0)
        {
            calculatedSalaries[currentNode] = 1;
            return 1;
        }
        else
        {
            long sum = 0;
            for (int i = 0; i < graph[currentNode].Count; i++)
            {
                sum += DFS(graph[currentNode][i], calculatedSalaries);
            }

            calculatedSalaries[currentNode] = sum;
            return sum;
        }
    }

    /// <summary>
    /// The method creates a graph based on the input lines.
    /// </summary>
    private static void AssembleGraph()
    {
        for (int i = 0; i < numberOfNodes; i++)
        {
            String currentLine = Console.ReadLine();
            for (int j = 0; j < currentLine.Length; j++)
            {
                if (currentLine[j] == 'Y')
                {
                    graph[i].Add(j);
                }
            }
        }
    }
}

