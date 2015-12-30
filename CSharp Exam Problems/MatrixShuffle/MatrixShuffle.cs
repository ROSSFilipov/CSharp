using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class MatrixShuffle
{
    private static string DIRECTION = "left";

    private static int CELL_COUNTER = 0;

    private static int X = 0;

    private static int Y = 0;

    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();

        char[,] maze = new char[size, size];
        bool[,] boolMaze = new bool[size, size];

        FillSpiralMatrix(maze, input, size, boolMaze);

        string evenSentence = string.Empty;

        string oddSentence = string.Empty;

        ExtractSentences(maze, size, ref evenSentence, ref oddSentence);

        string fullSentence = evenSentence + oddSentence;

        if (IsPalindrome(fullSentence))
        {
            Console.WriteLine("<div style='background-color:#4FE000'>{0} </div>", fullSentence);
        }
        else
        {
            Console.WriteLine("<div style='background-color:#E0000F'>{0} </div>", fullSentence);
        }
    }

    private static bool IsPalindrome(string fullSentence)
    {
        Regex charPattern = new Regex("[\\w]");
        bool isPalindrome = true;

        string clearedString = string.Join("", fullSentence.Where(x => charPattern.IsMatch(x.ToString())));

        char[] charArray = clearedString.ToCharArray();

        for (int i = 0, j = charArray.Length - 1; i < charArray.Length / 2; i++, j--)
        {
            if (charArray[i] != charArray[j])
            {
                isPalindrome = false;
            }
        }

        return isPalindrome;
    }

    private static void FillSpiralMatrix(char[,] maze, string input, int size, bool[,] boolMaze)
    {
        while (CELL_COUNTER < size * size - 1)
        {
            switch (DIRECTION)
            {
                case "left": FillLeft(maze, input, size, boolMaze);
                    break;
                case "right": FillRight(maze, input, size, boolMaze);
                    break;
                case "down": FillDown(maze, input, size, boolMaze);
                    break;
                case "up": FillUp(maze, input, size, boolMaze);
                    break;
                default:
                    {
                        throw new InvalidOperationException("This should never happen");
                    }
            }
        }
    }

    private static void FillLeft(char[,] maze, string input, int size, bool[,] boolMaze)
    {
        while (boolMaze[X, Y] == false)
        {
            maze[X, Y] = input[CELL_COUNTER % input.Length];
            boolMaze[X, Y] = true;
            CELL_COUNTER++;
            if (CELL_COUNTER == size * size - 1)
            {
                return;
            }
            Y++;
            if (Y == size)
            {
                break;
            }
        }
        DIRECTION = "down";
        X++;
        Y--;
    }

    private static void FillRight(char[,] maze, string input, int size, bool[,] boolMaze)
    {
        while (boolMaze[X, Y] == false)
        {
            maze[X, Y] = input[CELL_COUNTER % input.Length];
            boolMaze[X, Y] = true;
            CELL_COUNTER++;
            if (CELL_COUNTER == size * size - 1)
            {
                return;
            }
            Y--;
            if (Y < 0)
            {
                break;
            }
        }
        DIRECTION = "up";
        X--;
        Y++;
    }

    private static void FillDown(char[,] maze, string input, int size, bool[,] boolMaze)
    {
        while (boolMaze[X, Y] == false)
        {
            maze[X, Y] = input[CELL_COUNTER % input.Length];
            boolMaze[X, Y] = true;
            CELL_COUNTER++;
            if (CELL_COUNTER == size * size - 1)
            {
                return;
            }
            X++;
            if (X == size)
            {
                break;
            }
        }
        DIRECTION = "right";
        X--;
        Y--;
    }

    private static void FillUp(char[,] maze, string input, int size, bool[,] boolMaze)
    {
        while (boolMaze[X, Y] == false)
        {
            maze[X, Y] = input[CELL_COUNTER % input.Length];
            boolMaze[X, Y] = true;
            CELL_COUNTER++;
            if (CELL_COUNTER == size * size - 1)
            {
                return;
            }
            X--;
            if (X < 0)
            {
                break;
            }
        }
        DIRECTION = "left";
        X++;
        Y++;
    }

    private static void ExtractSentences(char[,] maze, int size, ref string evenSentence, ref string oddSentence)
    {
        Regex removePattern = new Regex("[\\w\\s]");
        for (int i = 0; i < size; i++)
        {
            int counter = i % 2 == 0 ? 0 : 1;
            for (int j = 0; j < size; j++)
            {
                if (counter % 2 == 0 && (removePattern.IsMatch(maze[i, j].ToString()) || maze[i, j] == '\0'))
                {
                    evenSentence += maze[i, j];
                    counter++;
                }
                else if (counter % 2 != 0 && (removePattern.IsMatch(maze[i, j].ToString()) || maze[i, j] == '\0'))
                {
                    oddSentence += maze[i, j];
                    counter++;
                }
            }
        }
    }
}

