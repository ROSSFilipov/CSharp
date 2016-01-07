using System;

class QuadronacciRectangle
{
    static void Main(string[] args)
    {
        long[] buffer = new long[4];
        buffer[0] = long.Parse(Console.ReadLine());
        buffer[1] = long.Parse(Console.ReadLine());
        buffer[2] = long.Parse(Console.ReadLine());
        buffer[3] = long.Parse(Console.ReadLine());
        int rows = int.Parse(Console.ReadLine());
        int collumns = int.Parse(Console.ReadLine());
        long[,] matrix = new long[rows, collumns];

        matrix[0, 0] = buffer[0];
        matrix[0, 1] = buffer[1];
        matrix[0, 2] = buffer[2];
        matrix[0, 3] = buffer[3];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < collumns; j++)
            {
                if (i == 0 && j <= 3)
                {
                    matrix[i, j] = buffer[j];
                }
                else
                {
                    matrix[i, j] = buffer[0] + buffer[1] + buffer[2] + buffer[3];
                    buffer[0] = buffer[1];
                    buffer[1] = buffer[2];
                    buffer[2] = buffer[3];
                    buffer[3] = matrix[i, j];
                }
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < collumns; j++)
            {
                Console.Write(matrix[i, j]);
                if (j < collumns - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}

