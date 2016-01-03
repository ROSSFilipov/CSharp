using System;
using System.Collections.Generic;
using System.Linq;

class GameOfLife
{
    private static int aliveCounter = 0;
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] matrixDetails = Console.ReadLine().Split();
        byte rows = byte.Parse(matrixDetails[0]);
        int collumns = int.Parse(matrixDetails[1]);
        byte[,] matrix = new byte[rows, collumns];
        FillMatrix(matrix, rows, collumns);

        bool hasChanges = true;
        while (true)
        {
            matrix = NextGeneration(matrix, rows, collumns, ref hasChanges);

            n--;
            if (n == 0 || !hasChanges)
            {
                Console.WriteLine(aliveCounter);
                break;
            }
        }
    }

    private static byte[,] NextGeneration(byte[,] matrix, int rows, int collumns, ref bool hasChanges)
    {
        byte[,] nextGenerationMatrix = new byte[rows, collumns];

        int numberOfChanges = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < collumns; j++)
            {
                int numberOfAliveNeighbours = CalculateAliveNeighbours(matrix, i, j, rows, collumns);
                if (matrix[i, j] == 0)
                {
                    switch (numberOfAliveNeighbours)
                    {
                        case 3:
                            nextGenerationMatrix[i, j] = 1;
                            numberOfChanges++;
                            aliveCounter++;
                            break;
                        default:
                            nextGenerationMatrix[i, j] = 0;
                            break;
                    }
                }
                else
                {
                    switch (numberOfAliveNeighbours)
                    {
                        case 2:
                        case 3:
                            nextGenerationMatrix[i, j] = 1;
                            break;
                        default:
                            nextGenerationMatrix[i, j] = 0;
                            numberOfChanges++; aliveCounter--;
                            break;
                    }
                }
            }
        }

        if (numberOfChanges == 0)
        {
            hasChanges = false;
        }

        return nextGenerationMatrix;
    }

    private static int CalculateAliveNeighbours(byte[,] matrix, int i, int j, int rows, int collumns)
    {
        int aliveNeighboursCounter = 0;
        if (IsAlive(matrix, i - 1, j - 1, rows, collumns))
        {
            aliveNeighboursCounter++;
        }

        if (IsAlive(matrix, i - 1, j, rows, collumns))
        {
            aliveNeighboursCounter++;
        }

        if (IsAlive(matrix, i - 1, j + 1, rows, collumns))
        {
            aliveNeighboursCounter++;
        }

        if (IsAlive(matrix, i, j - 1, rows, collumns))
        {
            aliveNeighboursCounter++;
        }

        if (IsAlive(matrix, i, j + 1, rows, collumns))
        {
            aliveNeighboursCounter++;
        }

        if (IsAlive(matrix, i + 1, j - 1, rows, collumns))
        {
            aliveNeighboursCounter++;
        }

        if (IsAlive(matrix, i + 1, j, rows, collumns))
        {
            aliveNeighboursCounter++;
        }

        if (IsAlive(matrix, i + 1, j + 1, rows, collumns))
        {
            aliveNeighboursCounter++;
        }

        return aliveNeighboursCounter;
    }

    private static bool IsAlive(byte[,] matrix, int i, int j, int rows, int collumns)
    {
        if (i < 0 || i >= rows || j < 0 || j >= collumns)
        {
            return false;
        }

        if (matrix[i, j] == 0)
        {
            return false;
        }

        return true;
    }

    private static void FillMatrix(byte[,] matrix, int rows, int collumns)
    {
        for (int i = 0; i < rows; i++)
        {
            byte[] currentLine = Console.ReadLine()
                .Split()
                .Select(byte.Parse)
                .ToArray();

            for (int j = 0; j < collumns; j++)
            {
                matrix[i, j] = currentLine[j];
                if (currentLine[j] == 1)
                {
                    aliveCounter++;
                }
            }
        }
    }
}
