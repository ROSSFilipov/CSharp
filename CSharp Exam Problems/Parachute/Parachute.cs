using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Parachute
{
    private static int X = 0;
    private static int Y = 0;

    private static bool IsGameOver = false;

    static void Main(string[] args)
    {
        int rowsCounter = 0;
        int colsCounter = 0;

        string input = TakeInput(ref rowsCounter, ref colsCounter);

        char[,] maze = new char[rowsCounter, colsCounter];

        FillMaze(maze, input);

        ExecuteFall(maze);

        Console.WriteLine("{0} {1}", X, Y);

    }

    private static string TakeInput(ref int linesCounter, ref int colsCounter)
    {
        StringBuilder sb = new StringBuilder();

        while (true)
        {
            string currentLine = Console.ReadLine().Trim();

            if (currentLine == "END")
            {
                break;
            }

            sb.AppendLine(currentLine);
            linesCounter++;
            colsCounter = currentLine.Length;
        }

        return sb.ToString();
    }

    private static void FillMaze(char[,] maze, string input)
    {
        string[] inputTable = input.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            string currentLine = inputTable[i];
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                maze[i, j] = currentLine[j];
                if (currentLine[j] == 'o')
                {
                    X = i;
                    Y = j;
                }
            }
        }
    }

    private static void ExecuteFall(char[,] maze)
    {
        for (int i = X + 1; i < maze.GetLength(0); i++)
        {
            int windPower = CalculateWindPower(i, maze);

            X = i;
            Y += windPower;

            Outcome(maze);

            if (IsGameOver)
            {
                return;
            }
        }
    }

    private static int CalculateWindPower(int i, char[,] maze)
    {
        int windPower = 0;

        for (int j = 0; j < maze.GetLength(1); j++)
        {
            if (maze[i, j] == '<')
            {
                windPower--;
            }
            else if (maze[i, j] == '>')
            {
                windPower++;
            }
            else
            {
                continue;
            }
        }

        return windPower;
    }

    private static void Outcome(char[,] maze)
    {
        switch (maze[X, Y])
        {
            case '-':
            case '>':
            case '<':
                return;
            case '_':
                Console.WriteLine("Landed on the ground like a boss!");
                IsGameOver = true;
                return;
            case '\\':
            case '/':
            case '|':
                Console.WriteLine("Got smacked on the rock like a dog!");
                IsGameOver = true;
                return;
            case '~':
                Console.WriteLine("Drowned in the water like a cat!");
                IsGameOver = true;
                return;
            case 'o':
                return;
            default:
                {
                    throw new InvalidOperationException("This should never happen");
                }
        }
    }
}

