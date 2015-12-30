using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class LabyrinthDash
{
    private static int LIVES = 3;

    private static int PositionX = 0;

    private static int PositionY = 0;

    private static bool IsGameOver = false;

    private static int MOVES = 0;

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        char[][] maze = new char[n][];

        FillMaze(maze, n);

        char[] moves = Console.ReadLine().Trim().ToCharArray();

        ExecuteMoves(maze, moves);

        Console.WriteLine("Total moves made: {0}", MOVES);
    }

    private static void FillMaze(char[][] maze, int n)
    {
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine().Trim();
            int currentRowLength = input.ToCharArray().Length;
            maze[i] = new char[currentRowLength];
            for (int j = 0; j < currentRowLength; j++)
            {
                maze[i][j] = input[j];
            }
        }
    }

    private static void ExecuteMoves(char[][] maze, char[] moves)
    {
        for (int i = 0; i < moves.Length; i++)
        {
            if (IsGameOver)
            {
                return;
            }
            else
            {
                switch (moves[i])
                {
                    case '<': MoveLeft(maze);
                        break;
                    case '>': MoveRight(maze);
                        break;
                    case '^': MoveUp(maze);
                        break;
                    case 'v': MoveDown(maze);
                        break;
                    default:
                        {
                            throw new InvalidOperationException("This should never happen");
                        }
                }
            }
        }
    }

    private static void MoveLeft(char[][] maze)
    {
        int newX = PositionX;
        int newY = PositionY - 1;
        Outcome(maze, newX, newY);
    }

    private static void MoveRight(char[][] maze)
    {
        int newX = PositionX;
        int newY = PositionY + 1;
        Outcome(maze, newX, newY);
    }

    private static void MoveUp(char[][] maze)
    {
        int newX = PositionX - 1;
        int newY = PositionY;
        Outcome(maze, newX, newY);
    }

    private static void MoveDown(char[][] maze)
    {
        int newX = PositionX + 1;
        int newY = PositionY;
        Outcome(maze, newX, newY);
    }

    private static void Outcome(char[][] maze, int newX, int newY)
    {
        if (newY < 0 || newX < 0 || newX > maze.GetLength(0) - 1 || newY > maze[newX].Length - 1)
        {
            MOVES++;
            Console.WriteLine("Fell off a cliff! Game Over!");
            IsGameOver = true;
            return;
        }
        else
        {
            switch (maze[newX][newY])
            {
                case '@':
                case '#':
                case '*':
                    MOVES++;
                    LIVES--;
                    PositionX = newX;
                    PositionY = newY;
                    if (LIVES == 0)
                    {
                        Console.WriteLine("No lives left! Game Over!");
                        IsGameOver = true;
                        return;
                    }
                    Console.WriteLine("Ouch! That hurt! Lives left: {0}", LIVES);
                    return;
                case '$':
                    MOVES++;
                    LIVES++;
                    Console.WriteLine("Awesome! Lives left: {0}", LIVES);
                    PositionX = newX;
                    PositionY = newY;
                    maze[newX][newY] = '.';
                    return;
                case '_':
                case '|':
                    Console.WriteLine("Bumped a wall.");
                    return;
                case ' ':
                    MOVES++;
                    Console.WriteLine("Fell off a cliff! Game Over!");
                    IsGameOver = true;
                    return;
                case '.':
                    MOVES++;
                    Console.WriteLine("Made a move!");
                    PositionX = newX;
                    PositionY = newY;
                    return;
                default:
                    {
                        throw new InvalidOperationException("This should never happen");
                    }
            }
        }
    }
}

