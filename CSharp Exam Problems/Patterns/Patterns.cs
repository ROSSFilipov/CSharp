using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Patterns
{
    private static long maxSum = 0;

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        TakeInput(matrix, n);

        for (int i = 0; i < n - 2; i++)
        {
            for (int j = 0; j < n - 4; j++)
            {
                int[] currentPattern = new int[] 
                    { 
                        matrix[i,j], 
                        matrix[i, j + 1],
                        matrix[i, j + 2],
                        matrix[i + 1, j + 2],
                        matrix[i + 2, j + 2],
                        matrix[i + 2, j + 3],
                        matrix[i + 2, j + 4]
                    };

                if (IsValidPattern(currentPattern))
                {
                    int tempSum = currentPattern.Sum();

                    if (tempSum > maxSum)
                    {
                        maxSum = tempSum;
                    }
                }
            }
        }

        if (maxSum == 0)
        {
            int diagonalSum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        diagonalSum += matrix[i, j];
                    }
                }
            }

            Console.WriteLine("NO {0}", diagonalSum);
        }
        else
        {
            Console.WriteLine("YES {0}", maxSum);
        }
    }

    private static bool IsValidPattern(int[] currentPattern)
    {
        bool isValid = true;

        for (int i = 1; i < currentPattern.Length; i++)
        {
            if (currentPattern[i] != currentPattern[i - 1] + 1)
            {
                isValid = false;
                break;
            }
        }

        return isValid;
    }

    private static void TakeInput(int[,] matrix, int n)
    {
        for (int i = 0; i < n; i++)
        {
            int[] currentLine = Console.ReadLine()
                .Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = currentLine[j];
            }
        }
    }
}

