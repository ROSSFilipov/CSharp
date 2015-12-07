using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectingCables
{
    class ConnectingCables
    {
        static void Main(string[] args)
        {
            int[] firstSide = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int[] secondSide = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            //int[] firstSide = new int[] { 2, 5, 3, 3, 3, 1, 8, 2, 6, 7, 6 };
            //int[] secondSide = new int[] { 1, 2, 5, 3, 4, 1, 7, 8, 2, 5, 6 };

            int firstSize = firstSide.Length + 1;
            int secondSize = secondSide.Length + 1;

            int[,] matrix = new int[firstSize, secondSize];

            FillMatrix(matrix, firstSide, secondSide, firstSize, secondSize);

            PrintMatrix(matrix);

            LinkedList<int> cables = new LinkedList<int>();

            FindConnectedCables(matrix, firstSide, secondSide, cables);

            //Console.WriteLine("Maximum pairs connected: {0}", cables.Count());
            //Console.WriteLine("Connected pairs: {0}", string.Join(" ", cables));
            Console.WriteLine(cables.Count());
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix(int[,] matrix, int[] firstSide, int[] secondSide, int firstSize, int secondSize)
        {
            for (int i = 1; i < firstSize; i++)
            {
                for (int j = 1; j < secondSize; j++)
                {
                    if (firstSide[i - 1] == secondSide[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        matrix[i, j] = Math.Max(matrix[i, j - 1], matrix[i - 1, j]);
                    }
                }
            }
        }

        private static void FindConnectedCables(int[,] matrix, int[] firstSide, int[] secondSide, LinkedList<int> cables)
        {
            int i = matrix.GetLength(0) - 1;
            int j = matrix.GetLength(1) - 1;
            bool[] usedUp = new bool[firstSide.Length];
            bool[] usedDown = new bool[secondSide.Length];

            var connections = new Dictionary<int, int>();

            while (i > 0 && j > 0)
            {
                if (firstSide[i - 1] == secondSide[j - 1] && matrix[i - 1, j - 1] + 1 == matrix[i, j])
                {
                    cables.AddFirst(firstSide[i - 1]);
                    connections.Add(i - 1, j - 1);
                    usedUp[i - 1] = true;
                    usedDown[j - 1] = true;
                    i--;
                    j--;
                }
                else if (matrix[i, j] == matrix[i - 1, j])
                {
                    i--;
                }
                else
                {
                    j--;
                }
            }

            CheckDuplicates(cables, connections, firstSide, secondSide, usedUp, usedDown);
        }

        private static void CheckDuplicates(LinkedList<int> cables, Dictionary<int, int> connections, int[] firstSide, int[] secondSide, bool[] usedUp, bool[] usedDown)
        {
            foreach (var edge in connections)
            {
                int up = edge.Key;
                int down = edge.Value;

                CheckLeftSide(cables, firstSide, secondSide, up, down, usedUp, usedDown);

                CheckRightSide(cables, firstSide, secondSide, up, down, usedUp, usedDown);
            }
        }

        private static void CheckRightSide(LinkedList<int> cables, int[] firstSide, int[] secondSide, int up, int down, bool[] usedUp, bool[] usedDown)
        {
            bool found = false;
            for (int i = up + 1; i < firstSide.Length; i++)
            {
                if (usedUp[i])
                {
                    break;
                }

                if (firstSide[i] == firstSide[up])
                {
                    cables.AddFirst(firstSide[i]);
                    found = true;
                }
            }

            if (!found)
            {
                for (int i = down + 1; i < secondSide.Length; i++)
                {
                    if (usedDown[i])
                    {
                        break;
                    }

                    if (secondSide[i] == secondSide[down])
                    {
                        cables.AddFirst(secondSide[i]);
                    }
                }
            }
        }

        private static void CheckLeftSide(LinkedList<int> cables, int[] firstSide, int[] secondSide, int up, int down, bool[] usedUp, bool[] usedDown)
        {
            bool found = false;
            for (int i = up - 1; i >= 0; i--)
            {
                if (usedUp[i])
                {
                    if (firstSide[i] == firstSide[up])
                    {
                        cables.AddFirst(firstSide[i]);
                        found = true;
                    }
                    break;
                }

                if (firstSide[i] == firstSide[up])
                {
                    cables.AddFirst(firstSide[i]);
                    found = true;
                }
            }

            if (!found)
            {
                for (int i = down - 1; i >= 0; i--)
                {
                    if (usedDown[i])
                    {
                        if (secondSide[i] == secondSide[down])
                        {
                            cables.AddFirst(secondSide[i]);
                        }
                        break;
                    }

                    if (secondSide[i] == secondSide[down])
                    {
                        cables.AddFirst(secondSide[i]);
                    }
                }
            }
        }
    }
}
