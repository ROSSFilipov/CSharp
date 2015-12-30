using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class StringMatrixRotation
{
    static string[,] matrix;
    static void Main(string[] args)
    {
        string[] command = Console.ReadLine().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        string input = Console.ReadLine();
        List<string> collection = new List<string>();
        int bestLength = 0;

        while (input != "END")
        {
            collection.Add(input);
            if (input.Length > bestLength)
            {
                bestLength = input.Length;
            }
            input = Console.ReadLine();
        }

        int degree = int.Parse(command[1].ToString());

        int counter = degree % 360;

        switch (counter)
        {
            case 0: matrix = RotateMatrix0(matrix, collection, bestLength); PrintMatrix(matrix);
                break;
            case 90: matrix = RotateMatrix90(matrix, collection, bestLength); PrintMatrix(matrix);
                break;
            case 180: matrix = RotateMatrix180(matrix, collection, bestLength); PrintMatrix(matrix);
                break;
            case 270: matrix = RotateMatrix270(matrix, collection, bestLength); PrintMatrix(matrix);
                break;
            default:
                {
                    //That should never happen
                    throw new InvalidOperationException();
                }
        }
    }

    private static string[,] RotateMatrix0(string[,] matrix, List<string> collection, int bestLength)
    {
        matrix = new string[collection.Count, bestLength];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string x = collection[i].PadRight(bestLength, ' ');
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = x[j].ToString();
            }
        }

        return matrix;
    }

    private static string[,] RotateMatrix270(string[,] matrix, List<string> collection, int bestLength)
    {
        matrix = new string[bestLength, collection.Count];
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            char[] x = collection[i].PadRight(bestLength, ' ').ToCharArray();
            Array.Reverse(x);
            for (int j = matrix.GetLength(0) - 1; j >= 0; j--)
            {
                matrix[j, i] = x[j].ToString();
            }
        }

        return matrix;
    }

    private static string[,] RotateMatrix180(string[,] matrix, List<string> collection, int bestLength)
    {
        matrix = new string[collection.Count, bestLength];
        for (int i = 0, i2 = matrix.GetLength(0) - 1; i < matrix.GetLength(0); i++, i2--)
        {
            char[] x = collection[i2].PadRight(bestLength, ' ').ToCharArray();
            Array.Reverse(x);
            for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
            {
                matrix[i, j] = x[j].ToString();
            }
        }

        return matrix;
    }

    private static string[,] RotateMatrix90(string[,] matrix, List<string> collection, int bestLength)
    {
        matrix = new string[bestLength, collection.Count];
        for (int i = 0, i2 = matrix.GetLength(1) - 1; i < matrix.GetLength(1); i++, i2--)
        {
            char[] x = collection[i2].PadRight(bestLength, ' ').ToCharArray();
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                matrix[j, i] = x[j].ToString();
            }
        }

        return matrix;
    }

    private static void PrintMatrix(string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}

