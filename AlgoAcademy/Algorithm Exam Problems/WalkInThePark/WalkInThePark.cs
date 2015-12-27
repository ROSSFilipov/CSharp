using System;
using System.Collections.Generic;
using System.Linq;

public class Edge
{
    public Edge(int node1, int node2)
    {
        this.ConnectedNodes = new HashSet<int>();
        this.ConnectedNodes.Add(node1);
        this.ConnectedNodes.Add(node2);
        this.IsVisited = false;
    }

    public bool IsVisited { get; set; }

    public HashSet<int> ConnectedNodes { get; set; }
}

/// <summary>
/// Below are two different solutions. The fast one
/// is based on a boolean matrix which allows us to
/// check whether the edge between two nodes has been
/// visited. The slow solution is based on a custom
/// class Edge and each time we want to visit a nearest
/// node we need to iterate through the list of Edges
/// to check if the edge connecting the nodes has been
/// visited which is much slower.
/// </summary>
public class WalkInThePark
{
    private static LinkedList<int> path = new LinkedList<int>();
    private static List<List<int>> pathsData = new List<List<int>>();
    private static int visitedEdges;
    private static bool[,] visited;
    private static int totalCounter = 0;
    static void Main(string[] args)
    {
        int numberOfNodes = int.Parse(Console.ReadLine());
        List<Edge> edgeData = new List<Edge>();
        List<int>[] adjacencyList = new List<int>[numberOfNodes];
        for (int i = 0; i < numberOfNodes; i++)
        {
            adjacencyList[i] = new List<int>();
        }

        bool isEulerGraph = true;
        visited = new bool[numberOfNodes, numberOfNodes];
        ReadEdges(edgeData, numberOfNodes, adjacencyList, ref isEulerGraph);

        visitedEdges = edgeData.Count;

        if (isEulerGraph)
        {
            DFS(0, 0, edgeData, adjacencyList);

            pathsData.Sort((x, y) =>
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
                });

            int routeCounter = 1;
            foreach (List<int> currentPath in pathsData)
            {
                Console.WriteLine("Route {0}: {1}", routeCounter, string.Join(" ", currentPath));
                routeCounter++;
            }

            Console.WriteLine("Number of routes: {0}", totalCounter);
        }
        else
        {
            Console.WriteLine("Number of routes: 0");
        }
    }

    private static void DFS(int currentNode, int startingNode, List<Edge> edgeData, List<int>[] adjacencyList)
    {
        //if (currentNode == startingNode && !edgeData.Any(x => !x.IsVisited))
        //{
        //    path.AddLast(startingNode);
        //    pathsData.Add(new List<int>(path));
        //    path.RemoveLast();
        //    totalCounter++;
        //    return;
        //}

        if (currentNode == startingNode && visitedEdges == 0)
        {
            path.AddLast(startingNode);
            pathsData.Add(new List<int>(path));
            path.RemoveLast();
            totalCounter++;
            return;
        }

        path.AddLast(currentNode);

        foreach (int connectedNode in adjacencyList[currentNode])
        {
            //Edge currentEdge = edgeData.FirstOrDefault(x => 
            //    x.ConnectedNodes.Contains(currentNode) 
            //    && x.ConnectedNodes.Contains(connectedNode) 
            //    && !x.IsVisited);

            //if (currentEdge != null)
            //{
            //    currentEdge.IsVisited = true;
            //    DFS(connectedNode, startingNode, edgeData, adjacencyList);
            //    currentEdge.IsVisited = false;
            //}

            if (!visited[currentNode, connectedNode] || !visited[connectedNode, currentNode])
            {
                visited[currentNode, connectedNode] = true;
                visited[connectedNode, currentNode] = true;
                visitedEdges--;
                DFS(connectedNode, startingNode, edgeData, adjacencyList);
                visitedEdges++;
                visited[currentNode, connectedNode] = false;
                visited[connectedNode, currentNode] = false;
            }
        }

        path.RemoveLast();
    }

    /// <summary>
    /// A graph could be an Euler graph only in case
    /// each node has even number of neighbours. If
    /// not we stop the execution of the program at
    /// the beginning to save time.
    /// </summary>
    /// <param name="edgeData"></param>
    /// <param name="numberOfNodes"></param>
    /// <param name="adjacencyList"></param>
    /// <param name="isEulerGraph"></param>
    private static void ReadEdges(List<Edge> edgeData, int numberOfNodes, List<int>[] adjacencyList, ref bool isEulerGraph)
    {
        for (int i = 0; i < numberOfNodes; i++)
        {
            string currentLine = Console.ReadLine();
            for (int j = 0; j < numberOfNodes; j++)
            {
                if (currentLine[j] == '1')
                {
                    if (!edgeData.Any(x => x.ConnectedNodes.Contains(i) && x.ConnectedNodes.Contains(j)))
                    {
                        edgeData.Add(new Edge(i, j));
                    }
                    adjacencyList[i].Add(j);
                }
            }

            if (adjacencyList[i].Count % 2 != 0)
            {
                isEulerGraph = false;
            }
        }
    }
}

