using System;
using System.Collections.Generic;
using System.Linq;

class Edge
{
    public Edge(int source, int destination, int cost)
    {
        this.Source = source;
        this.Destination = destination;
        this.Cost = cost;
    }

    public int Source { get; set; }

    public int Destination { get; set; }

    public int Cost { get; set; }
}

class GravityTrader
{
    static void Main(string[] args)
    {
        int numberOfNodes = int.Parse(Console.ReadLine());
        int numberOfEdges = int.Parse(Console.ReadLine());

        List<Edge> edgeData = new List<Edge>();

        AssembleGraph(edgeData, numberOfNodes, numberOfEdges);
        long[] distances = new long[numberOfNodes];
        for (int i = 0; i < numberOfNodes; i++)
        {
            distances[i] = int.MaxValue;
        }

        UpdateDistances(edgeData, distances, numberOfNodes, numberOfEdges);

        if (NegativeCycleDetected(distances, edgeData, numberOfNodes))
        {
            Console.WriteLine("Black hole!");
        }
        else
        {
            foreach (int node in distances)
            {
                if (node == int.MaxValue)
                {
                    Console.WriteLine("Unreachable!");
                }
                else
                {
                    Console.WriteLine(node);
                }
            }
        }
    }

    /// <summary>
    /// The solution uses an implementation
    /// of the Bellman-Ford algorithm.
    /// </summary>
    /// <param name="edgeData">A collection of all edges.</param>
    /// <param name="distances">An array to keep and upgrade distances between nodes.</param>
    /// <param name="numberOfNodes"></param>
    /// <param name="numberOfEdges"></param>
    private static void UpdateDistances(List<Edge> edgeData, long[] distances, int numberOfNodes, int numberOfEdges)
    {
        distances[0] = 0;
        bool changed = true;
        for (int node = 0; node < numberOfNodes; node++)
        {
            changed = false;
            for (int currentEdge = 0; currentEdge < numberOfEdges; currentEdge++)
            {
                if (distances[edgeData[currentEdge].Destination] > distances[edgeData[currentEdge].Source]
                    + edgeData[currentEdge].Cost)
                {
                    distances[edgeData[currentEdge].Destination] = distances[edgeData[currentEdge].Source]
                        + edgeData[currentEdge].Cost;
                    changed = true;
                }
            }

            if (!changed)
            {
                break;
            }
        }
    }

    private static void AssembleGraph(List<Edge> edgeData, int numberOfNodes, int numberOfEdges)
    {
        for (int i = 0; i < numberOfEdges; i++)
        {
            int[] currentEdge = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            edgeData.Add(new Edge(currentEdge[0], currentEdge[1], currentEdge[2]));
        }
    }

    private static bool NegativeCycleDetected(long[] distances, List<Edge> edgeData, int numberOfNodes)
    {
        foreach (Edge currentEdge in edgeData)
        {
            if (distances[currentEdge.Source] != int.MaxValue)
            {
                if (distances[currentEdge.Destination] > distances[currentEdge.Source] + currentEdge.Cost)
                {
                    return true;
                }
            }
        }

        return false;
    }
}

