using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class ITVillage
{
    static void Main(string[] args)
    {
        //85/100
        string input1 = Console.ReadLine();
        string[] text = input1.Replace(" ", "").Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        string[] coordinates = Console.ReadLine().Split();
        string[] moves = Console.ReadLine().Split();
        int[] arrayMoves = new int[moves.Length];

        for (int i = 0; i < moves.Length; i++)
        {
            arrayMoves[i] = int.Parse(moves[i]);
        }

        bool[,] boolMatrix = new bool[4, 4];
        int rowPosition = int.Parse(coordinates[0]) - 1;
        int colPosition = int.Parse(coordinates[1]) - 1;
        int numberOfInns = String.Join("", text).ToCharArray().Where(x => x == 'F').Count();

        char[,] matrix = new char[4, 4];

        FillMatrix(text, matrix);

        string direction = String.Empty;

        direction = SwitchPosition(rowPosition, colPosition, direction);

        int coins = 50;
        int innsCount = 0;
        bool foundNakov = false;
        bool gameOver = false;

        for (int i = 0; i < arrayMoves.Length; i++)
        {
            if (foundNakov == true)
            {
                gameOver = true;
                Console.WriteLine("<p>You won! Nakov's force was with you!<p>");
                break;
            }
            if (coins < 0)
            {
                gameOver = true;
                Console.WriteLine("<p>You lost! You ran out of money!<p>");
                break;
            }
            if (numberOfInns == innsCount)
            {
                gameOver = true;
                Console.WriteLine("<p>You won! You own the village now! You have {0} coins!<p>", coins);
                break;
            }
            int currentMove = arrayMoves[i];
            while (currentMove > 0)
            {
                switch (direction)
                {
                    case "right": ExecuteRightDirection(ref rowPosition, ref colPosition, ref direction, ref coins, innsCount, ref currentMove);
                        break;
                    case "down": ExecuteDownDirection(ref rowPosition, ref direction, ref coins, innsCount, ref currentMove);
                        break;
                    case "left": ExecuteLeftDirection(ref colPosition, ref direction, ref coins, innsCount, ref currentMove);
                        break;
                    case "up": ExecuteUpDirection(ref rowPosition, ref direction, ref coins, innsCount, ref currentMove);
                        break;
                    default: throw new InvalidOperationException();
                }
            }

            CoinCollection(rowPosition, colPosition, matrix, ref coins, ref innsCount, ref foundNakov, ref i);
        }
        if (gameOver == false)
        {
            Console.WriteLine("<p>You lost! No more moves! You have {0} coins!<p>", coins);
        }
    }

    private static void ExecuteRightDirection(ref int rowPosition, ref int colPosition, ref string direction, ref int coins, int innsCount, ref int currentMove)
    {
        for (int i1 = rowPosition; i1 < 4; i1++)
        {
            colPosition++;
            currentMove--;
            coins += innsCount * 20;
            if (colPosition == 3)
            {
                break;
            }
            if (currentMove == 0)
            {
                break;
            }
        }
        if (colPosition == 3)
        {
            direction = "down";
        }
    }

    private static void ExecuteDownDirection(ref int rowPosition, ref string direction, ref int coins, int innsCount, ref int currentMove)
    {
        for (int i1 = rowPosition; i1 < 4; i1++)
        {
            rowPosition++;
            currentMove--;
            coins += innsCount * 20;
            if (rowPosition == 3)
            {
                break;
            }
            if (currentMove == 0)
            {
                break;
            }
        }
        if (rowPosition == 3)
        {
            direction = "left";
        }
    }

    private static void ExecuteLeftDirection(ref int colPosition, ref string direction, ref int coins, int innsCount, ref int currentMove)
    {
        for (int i1 = colPosition; i1 >= 0; i1--)
        {
            colPosition--;
            currentMove--;
            coins += innsCount * 20;
            if (colPosition == 0)
            {
                break;
            }
            if (currentMove == 0)
            {
                break;
            }
        }
        if (colPosition == 0)
        {
            direction = "up";
        }
    }

    private static void ExecuteUpDirection(ref int rowPosition, ref string direction, ref int coins, int innsCount, ref int currentMove)
    {
        for (int i1 = rowPosition; i1 >= 0; i1--)
        {
            rowPosition--;
            currentMove--;
            coins += innsCount * 20;
            if (rowPosition == 0)
            {
                break;
            }
            if (currentMove == 0)
            {
                break;
            }
        }
        if (rowPosition == 0)
        {
            direction = "right";
        }
    }

    private static void CoinCollection(int rowPosition, int colPosition, char[,] matrix, ref int coins, ref int innsCount, ref bool Nakov, ref int i)
    {
        switch (matrix[rowPosition, colPosition])
        {
            case 'P': coins -= 5;
                break;
            case 'I':
                if (coins >= 100)
                {
                    coins -= 100;
                    innsCount++;
                }
                else
                {
                    coins -= 10;
                }
                break;
            case 'F': coins += 20;
                break;
            case 'S': i += 2;
                break;
            case 'V': coins *= 10;
                break;
            case 'N': Nakov = true;
                break;
            default:
                break;
        }
    }

    private static string SwitchPosition(int rowPosition, int colPosition, string direction)
    {
        switch (rowPosition)
        {
            case 0: switch (colPosition)
                {
                    case 0:
                    case 1:
                    case 2: direction = "right";
                        break;
                    case 3: direction = "down";
                        break;
                    default:
                        break;
                }
                break;
            case 1:
            case 2:
            case 3: switch (colPosition)
                {
                    case 0: direction = "up";
                        break;
                    case 1:
                    case 2:
                    case 3: direction = "left";
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        return direction;
    }

    private static void FillMatrix(string[] text, char[,] matrix)
    {
        for (int i = 0; i < 4; i++)
        {
            string temp = text[i];
            for (int j = 0; j < 4; j++)
            {
                matrix[i, j] = temp[j];
            }
        }
    }
}

