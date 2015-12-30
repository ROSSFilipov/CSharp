using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Bunnies
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

        int rows = int.Parse(input[0]);
        int cols = int.Parse(input[1]);

        int playerX = 0;
        int playerY = 0;

        char[,] matrix = new char[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            string currentLine = Console.ReadLine();
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = currentLine[j];
                if (currentLine[j] == 'P')
                {
                    playerX = i;
                    playerY = j;
                    matrix[i, j] = '.';
                }
            }
        }

        //char[,] matrix = new char[,]
        //{
        //    {'.', '.', '.', '.', '.', '.', '.', 'B'},
        //    {'.', '.', '.', 'B', '.', '.', '.', '.'},
        //    {'.', '.', '.', '.', 'B', '.', '.', 'B'},
        //    {'.', '.', '.', '.', '.', '.', '.', '.'},
        //    {'.', '.', 'P', '.', '.', '.', '.', '.'}
        //};

        //int playerX = 4;
        //int playerY = 2;

        string moves = Console.ReadLine();

        bool isGameOver = false;
        bool playerDead = false;
        for (int i = 0; i < moves.Length; i++)
        {
            if (isGameOver)
            {
                //PrintMatrix(matrix);
                //Console.WriteLine("won: {0} {1}", playerX, playerY);
                break;
            }

            if (playerDead)
            {
                //PrintMatrix(matrix);
                //Console.WriteLine("dead: {0} {1}", playerX, playerY);
                break;
            }

            switch (moves[i])
            {
                case 'L': Move(matrix, ref playerX, ref playerY, ref isGameOver, ref playerDead, 0, -1);
                    SpreadBunnies(matrix, playerX, playerY, ref playerDead);
                    break;
                case 'R': Move(matrix, ref playerX, ref playerY, ref isGameOver, ref playerDead, 0, 1);
                    SpreadBunnies(matrix, playerX, playerY, ref playerDead);
                    break;
                case 'U': Move(matrix, ref playerX, ref playerY, ref isGameOver, ref playerDead, -1, 0);
                    SpreadBunnies(matrix, playerX, playerY, ref playerDead);
                    break;
                case 'D': Move(matrix, ref playerX, ref playerY, ref isGameOver, ref playerDead, 1, 0);
                    SpreadBunnies(matrix, playerX, playerY, ref playerDead);
                    break;
                default:
                    break;
            }
        }


        if (isGameOver)
        {
            PrintMatrix(matrix);
            Console.WriteLine("won: {0} {1}", playerX, playerY);
        }
        else
        {
            PrintMatrix(matrix);
            Console.WriteLine("dead: {0} {1}", playerX, playerY);
        }
    }

    private static void SpreadBunnies(char[,] matrix, int playerX, int playerY, ref bool playerDead)
    {
        List<Tuple<int, int>> bunnies = new List<Tuple<int, int>>();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 'B')
                {
                    bunnies.Add(new Tuple<int, int>(i, j));
                }
            }
        }

        for (int i = 0; i < bunnies.Count; i++)
        {
            ExecuteSpread(matrix, bunnies[i].Item1, bunnies[i].Item2, 0, -1, playerX, playerY, ref playerDead);
            ExecuteSpread(matrix, bunnies[i].Item1, bunnies[i].Item2, 0, 1, playerX, playerY, ref playerDead);
            ExecuteSpread(matrix, bunnies[i].Item1, bunnies[i].Item2, -1, 0, playerX, playerY, ref playerDead);
            ExecuteSpread(matrix, bunnies[i].Item1, bunnies[i].Item2, 1, 0, playerX, playerY, ref playerDead);
        }
    }

    private static void ExecuteSpread(char[,] matrix, int i, int j, int p1, int p2, int playerX, int playerY, ref bool playerDead)
    {
        int newX = i + p1;
        int newY = j + p2;

        if (newX < 0 || newX >= matrix.GetLength(0) || newY < 0 || newY >= matrix.GetLength(1))
        {
            return;
        }

        if (newX == playerX && newY == playerY)
        {
            matrix[newX, newY] = 'B';
            playerDead = true;
        }

        matrix[newX, newY] = 'B';
    }

    private static void PrintMatrix(char[,] matrix)
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

    private static void Move(char[,] matrix, ref int playerX, ref int playerY, ref bool isGameOver, ref bool playerDead, int x, int y)
    {
        int newX = playerX + x;
        int newY = playerY + y;

        if (newX < 0 || newX > matrix.GetLength(0) - 1 || newY < 0 || newY > matrix.GetLength(1) - 1)
        {
            isGameOver = true;
            return;
        }

        playerX = newX;
        playerY = newY;

        if (matrix[newX, newY] == 'B')
        {
            playerDead = true;
            return;
        }
    }
}

