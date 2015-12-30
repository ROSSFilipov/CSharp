using System;
using System.Collections.Generic;
using System.Linq;

public class Edge : IComparable<Edge>
{
    public Edge(int source, int destination, long cost)
    {
        this.Source = source;
        this.Destination = destination;
        this.Cost = cost;
    }

    public int Source { get; set; }

    public int Destination { get; set; }

    public long Cost { get; set; }

    public int CompareTo(Edge other)
    {
        return -this.Cost.CompareTo(other.Cost);
    }
}

public class Truck
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine()
            .Split();

        int numberOfNodes = int.Parse(input[0]);
        int numberOfEdges = int.Parse(input[1]);

        SpanningTreeSolution(numberOfNodes, numberOfEdges);
    }

    private static void SpanningTreeSolution(int numberOfNodes, int numberOfEdges)
    {
        List<Edge> edgeData = new List<Edge>();
        ReadEdgeData(edgeData, numberOfEdges);

        edgeData.Sort();

        //List<Edge> MST = new List<Edge>();
        long maximalHeight = long.MaxValue;
        int[] rootArray = new int[numberOfNodes + 1];
        for (int i = 1; i < numberOfNodes + 1; i++)
        {
            rootArray[i] = i;
        }

        foreach (Edge currentEdge in edgeData)
        {
            int rootOne = FindRoot(rootArray, currentEdge.Source);
            int rootTwo = FindRoot(rootArray, currentEdge.Destination);
            if (rootOne != rootTwo)
            {
                rootArray[rootOne] = rootTwo;
                if (currentEdge.Cost < maximalHeight)
                {
                    maximalHeight = currentEdge.Cost;
                }
            }
        }

        Console.WriteLine(maximalHeight);
        //foreach (Edge currentEdge in MST)
        //{
        //    Console.WriteLine("{0} -> {1} : {2}", currentEdge.Source, currentEdge.Destination, currentEdge.Cost);
        //}
    }

    private static int FindRoot(int[] rootArray, int node)
    {
        int root = node;
        while (root != rootArray[root])
        {
            root = rootArray[root];
        }

        return root;
    }

    private static void ReadEdgeData(List<Edge> edgeData, int numberOfEdges)
    {
        for (int i = 0; i < numberOfEdges; i++)
        {
            string[] currentEdge = Console.ReadLine()
                .Split();

            edgeData.Add(new Edge(int.Parse(currentEdge[0]), int.Parse(currentEdge[1]), long.Parse(currentEdge[2])));
        }
    }
}

