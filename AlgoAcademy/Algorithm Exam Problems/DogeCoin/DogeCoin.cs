using System;

class DogeCoin
{
    static void Main(string[] args)
    {
        int[] dimensions = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        byte[,] matrix = new byte[dimensions[0] + 1, dimensions[1] + 1];
        int numberOfCoins = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCoins; i++)
        {
            int[] currentCoin = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            matrix[currentCoin[0] + 1, currentCoin[1] + 1]++;
        }

        int[,] resultMatrix = new int[dimensions[0] + 1, dimensions[1] + 1];

        DistributeSums(matrix, resultMatrix, dimensions[0] + 1, dimensions[1] + 1);

        Console.WriteLine(resultMatrix[dimensions[0], dimensions[1]]);
    }

    private static void DistributeSums(byte[,] matrix, int[,] resultMatrix, int rows, int collumns)
    {
        for (int i = 0; i < rows; i++)
        {
            resultMatrix[i, 0] = matrix[i, 0];
        }

        for (int i = 0; i < collumns; i++)
        {
            resultMatrix[0, i] = matrix[0, i];
        }

        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < collumns; j++)
            {
                int currentCell = matrix[i, j];
                resultMatrix[i, j] = Math.Max(resultMatrix[i - 1, j], resultMatrix[i, j - 1]);
                resultMatrix[i, j] += currentCell;
            }
        }
    }
}

