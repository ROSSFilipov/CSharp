using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BunkerBuster
{
    static void Main(string[] args)
    {
        string[] coordinates = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        int rows = int.Parse(coordinates[0]);
        int cols = int.Parse(coordinates[1]);
        int[,] matrix = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            string[] cells = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = int.Parse(cells[j]);
            }
        }
        string bomb = Console.ReadLine();

        ExecuteBomb(matrix, bomb, rows, cols);

        int cellsDestroyed = CountDestroyedCells(matrix, rows, cols);

        decimal damage = (cellsDestroyed * 100) / (decimal)(rows * cols);
        Console.WriteLine("Destroyed bunkers: {0}", cellsDestroyed);
        if (cellsDestroyed != 0)
        {
            Console.WriteLine("Damage done: {0:F1} %", damage);
        }
        else
        {
            Console.WriteLine("Damage done: {0} %", 0);
        }
    }

    private static int CountDestroyedCells(int[,] matrix, int rows, int cols)
    {
        int cellsDestroyed = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] <= 0)
                {
                    cellsDestroyed++;
                }
            }
        }
        return cellsDestroyed;
    }

    private static void ExecuteBomb(int[,] matrix, string bomb, int rows, int cols)
    {
        while (bomb != "cease fire!")
        {
            string[] bombCoordinates = bomb.Split(new[] { ' ', '\t' });
            int bombRow = int.Parse(bombCoordinates[0]);
            int bombCol = int.Parse(bombCoordinates[1]);
            int bombPower = (int)Math.Ceiling(char.Parse(bombCoordinates[2]) / 2.0);

            matrix[bombRow, bombCol] -= (int)char.Parse(bombCoordinates[2]);
            for (int i = (bombRow - 1 < 0 ? 0 : bombRow - 1); i <= (bombRow + 1 > rows - 1 ? rows - 1 : bombRow + 1); i++)
            {
                for (int j = (bombCol - 1 < 0 ? 0 : bombCol - 1); j <= (bombCol + 1 > cols - 1 ? cols - 1 : bombCol + 1); j++)
                {
                    if (i == bombRow && j == bombCol)
                    {
                        continue;
                    }
                    matrix[i, j] -= bombPower;
                }
            }
            bomb = Console.ReadLine();
        }
    }
}

