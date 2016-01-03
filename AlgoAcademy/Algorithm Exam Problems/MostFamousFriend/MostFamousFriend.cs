using System;
using System.Collections.Generic;
using System.Linq;

class MostFamousFriend
{
    static void Main(string[] args)
    {
        int numberOfNodes = int.Parse(Console.ReadLine());
        HashSet<int>[] graph = new HashSet<int>[numberOfNodes];
        for (int i = 0; i < numberOfNodes; i++)
        {
            graph[i] = new HashSet<int>();
        }

        int[] friendsArray = new int[numberOfNodes];
        int highestNumberOfFriends = 0;
        ReadGraph(graph, friendsArray, numberOfNodes, ref highestNumberOfFriends);
        FindBiggestNumberOfFriends(graph, friendsArray, numberOfNodes, ref highestNumberOfFriends);

        Console.WriteLine(highestNumberOfFriends / 2);
    }

    private static void FindBiggestNumberOfFriends(HashSet<int>[] graph, int[] friendsArray, int numberOfNodes, ref int highestNumberOfFriends)
    {
        for (int i = 0; i < numberOfNodes; i++)
        {
            for (int j = 0; j < numberOfNodes; j++)
            {
                if (i != j && !graph[i].Contains(j))
                {
                    foreach (int friend in graph[i])
                    {
                        if (graph[j].Contains(friend))
                        {
                            friendsArray[i]++;
                            if (friendsArray[i] > highestNumberOfFriends)
                            {
                                highestNumberOfFriends = friendsArray[i];
                            }

                            friendsArray[j]++;
                            if (friendsArray[j] > highestNumberOfFriends)
                            {
                                highestNumberOfFriends = friendsArray[j];
                            }
                            break;
                        }
                    }
                }
            }
        }
    }

    private static void ReadGraph(HashSet<int>[] graph, int[] friendsArray, int numberOfNodes, ref int highestNumberOfFriends)
    {
        for (int i = 0; i < numberOfNodes; i++)
        {
            string currentLine = Console.ReadLine();
            for (int j = 0; j < currentLine.Length; j++)
            {
                if (currentLine[j] == 'Y')
                {
                    graph[i].Add(j);
                    graph[j].Add(i);

                    friendsArray[i]++;
                    if (friendsArray[i] > highestNumberOfFriends)
                    {
                        highestNumberOfFriends = friendsArray[i];
                    }

                    friendsArray[j]++;
                    if (friendsArray[j] > highestNumberOfFriends)
                    {
                        highestNumberOfFriends = friendsArray[j];
                    }
                }
            }
        }
    }
}

