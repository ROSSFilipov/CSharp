using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestRectangle
{
    class LargestRectangle
    {
        static void Main(string[] args)
        {
            //unfinished
            List<string[]> collection = new List<string[]>();
            
            UserInput(collection);

            int rows = collection.Count;
            int cols = collection[0].Length;
            string[,] matrix = new string[rows, cols];
            bool[,] boolArray = new bool[rows, cols];

            FillMatrix(matrix, collection, rows, cols);

            int bestRowOne = 0;
            int bestRowTwo = 0;
            int bestColOne = 0;
            int bestColTwo = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    string currentString = matrix[i, j];
                    int tempRowOne = 0;
                    int tempRowTwo = 0;
                    int tempColOne = 0;
                    int tempColTwo = 0;
                    for (int i1 = i; i1 < rows; i1++)
                    {
                        if (matrix[i1, j] == currentString)
                        {
                            tempRowOne++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int i1 = j; i1 < cols; i1++)
                    {
                        if (matrix[tempRowOne - 1, i1] == currentString)
                        {
                            tempColOne++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int i1 = j; i1 < cols; i1++)
                    {
                        if (matrix[i, i1] == currentString)
                        {
                            tempColTwo++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int i1 = i; i1 < rows; i1++)
                    {
                        if (matrix[i1, tempColTwo] == currentString)
                        {
                            tempRowTwo++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if ((tempRowOne == tempRowTwo && tempColOne == tempColTwo)
                        && tempRowOne * tempColOne > bestRowOne * bestColOne)
                    {
                        bestRowOne = tempRowOne;
                        bestRowTwo = tempRowTwo;
                        bestColOne = tempColOne;
                        bestColTwo = tempColTwo;
                    }
                }
            }
            Console.WriteLine("{0} x {1}", bestRowOne, bestColOne);
        }

        
        private static void UserInput(List<string[]> collection)
        {
            string[] input = Console.ReadLine().Split(new []{','}, StringSplitOptions.RemoveEmptyEntries);
            while (true)
            {
                if (input[0] == "END")
                {
                    break;
                }
                collection.Add(input);
                input = Console.ReadLine().Split(new []{','}, StringSplitOptions.RemoveEmptyEntries );
            }
        }

        private static void FillMatrix(string[,] matrix, List<string[]> collection, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                string[] temp = collection[i];
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = temp[j];
                }
            }
        }
    }
}
