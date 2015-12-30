using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class LoverOf3
{
    static void Main(string[] args)
    {
        int[] dimensions = Console.ReadLine()
            .Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int n = int.Parse(Console.ReadLine());

        string[] commands = new string[n];

        TakeInput(commands);

        int rows = dimensions[0];
        int cols = dimensions[1];

        int[,] matrix = new int[rows, cols];

        FillMatrix(matrix, rows, cols);

        long sum = CollectValues(matrix, commands, rows, cols);

        Console.WriteLine(sum);
    }

    private static long CollectValues(int[,] matrix, string[] commands, int rows, int cols)
    {
        long sum = 0;
        int positionX = rows - 1;
        int positionY = 0;

        for (int i = 0; i < commands.Length; i++)
        {
            string[] currentCommand = commands[i].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            string direction = currentCommand[0];
            int steps = int.Parse(currentCommand[1]);

            switch (direction)
            {
                case "RU":
                case "UR": ExecuteMovement(matrix, ref positionX, ref positionY, ref sum, -1, 1, steps, rows, cols);
                    break;
                case "LU":
                case "UL": ExecuteMovement(matrix, ref positionX, ref positionY, ref sum, -1, -1, steps, rows, cols);
                    break;
                case "DL":
                case "LD": ExecuteMovement(matrix, ref positionX, ref positionY, ref sum, 1, -1, steps, rows, cols);
                    break;
                case "RD":
                case "DR": ExecuteMovement(matrix, ref positionX, ref positionY, ref sum, 1, 1, steps, rows, cols);
                    break;
                default:
                    {
                        throw new InvalidOperationException("This should never happen.");
                    }
            }
        }

        return sum;
    }

    private static void ExecuteMovement(int[,] matrix, ref int positionX, ref int positionY, ref long sum, int p1, int p2, int steps, int rows, int cols)
    {
        steps--;
        while (steps >= 0)
        {
            sum += matrix[positionX, positionY];
            matrix[positionX, positionY] = 0;

            positionX += p1;
            positionY += p2;

            if (positionX < 0 ||
                positionX > rows - 1 ||
                positionY < 0 ||
                positionY > cols - 1)
            {
                break;
            }

            steps--;
        }

        positionX -= p1;
        positionY -= p2;
    }

    private static void TakeInput(string[] commands)
    {
        for (int i = 0; i < commands.Length; i++)
        {
            commands[i] = Console.ReadLine().Trim();
        }
    }

    private static void FillMatrix(int[,] matrix, int rows, int cols)
    {
        for (int i = 0; i < cols; i++)
        {
            matrix[rows - 1, i] = i * 3;
            for (int j = rows - 2; j >= 0; j--)
            {
                matrix[j, i] = matrix[j + 1, i] + 3;
            }
        }
    }
}

