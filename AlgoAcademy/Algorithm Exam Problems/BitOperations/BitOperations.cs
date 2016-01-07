using System;
using System.Collections.Generic;
using System.Linq;

class BitOperations
{
    static void Main(string[] args)
    {
        string firstLine = Console.ReadLine();
        string secondLine = Console.ReadLine();
        int sizeOne = firstLine.Length;
        int sizeTwo = secondLine.Length;

        double[,] matrix = new double[sizeOne + 1, sizeTwo + 1];
        for (int i = 1; i < sizeOne + 1; i++)
        {
            matrix[i, 0] = matrix[i - 1, 0] + CalculateDeleteCost(firstLine[i - 1]);
        }

        for (int i = 1; i < sizeTwo + 1; i++)
        {
            matrix[0, i] = matrix[0, i - 1] + CalculateInsertCost(secondLine[i - 1]);
        }

        for (int i = 1; i < sizeOne + 1; i++)
        {
            for (int j = 1; j < sizeTwo + 1; j++)
            {
                double replaceCost = 0;
                if (firstLine[i - 1] != secondLine[j - 1])
                {
                    replaceCost = 1;
                }

                replaceCost += matrix[i - 1, j - 1];

                double insertCost = CalculateInsertCost(secondLine[j - 1]);
                insertCost += matrix[i, j - 1];

                double deleteCost = CalculateDeleteCost(firstLine[i - 1]);
                deleteCost += matrix[i - 1, j];

                matrix[i, j] = Math.Min(Math.Min(replaceCost, insertCost), deleteCost);
            }
        }

        Console.WriteLine(matrix[sizeOne, sizeTwo]);
    }

    public static double CalculateInsertCost(char currentBit)
    {
        if (currentBit == '1')
        {
            return 1.2;
        }
        else
        {
            return 1.1;
        }
    }

    public static double CalculateDeleteCost(char currentBit)
    {
        if (currentBit == '1')
        {
            return 0.8;
        }
        else
        {
            return 0.9;
        }
    }
}

