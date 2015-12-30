using System;
using System.Collections.Generic;
using System.Linq;

class LineInverter
{
    private static char[,] gameBoard;
    private static int inversionCounter = 0;
    private static int whiteCounter = 0;
    private static int blackCounter = 0;
    private static readonly HashSet<int> usedRows = new HashSet<int>();
    private static readonly HashSet<int> usedCollumns = new HashSet<int>();
    private static bool solutionFound = false;
    static void Main(string[] args)
    {
        int boardSize = int.Parse(Console.ReadLine());
        CreateGameBoard(boardSize);
        InvertGameBoard(boardSize);
        //PrintGameBoard(boardSize);

        if (!solutionFound)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine(inversionCounter);
        }
    }

    private static void InvertGameBoard(int boardSize)
    {
        while (whiteCounter > 0)
        {
            if (!SolutionFound(boardSize))
            {
                return;
            }

            inversionCounter++;

            //PrintGameBoard(boardSize);
        }

        solutionFound = true;
    }

    /// <summary>
    /// A help method for keeping track on the gameboard
    /// after each invertion.
    /// </summary>
    private static void PrintGameBoard(int boardSize)
    {
        Console.WriteLine();
        Console.WriteLine();
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                Console.Write(gameBoard[i, j]);
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// The method find the first possible solution
    /// which increases either the number of black
    /// connected areas or the total number of black
    /// elements on the gameboard. The method contains 
    /// a greedy element which might be the cause for
    /// the 90/100 result.
    /// </summary>
    private static bool SolutionFound(int boardSize)
    {
        int connectedBlackCells = CalculateConnectedCells(boardSize);
        if (connectedBlackCells == 1 && whiteCounter == 0)
        {
            whiteCounter = 0;
            return true;
        }

        for (int i = 0; i < boardSize; i++)
        {
            if (!usedRows.Contains(i))
            {
                int currentBlackCounter = blackCounter;
                InvertRow(i, boardSize);
                int currentBlackCells = CalculateConnectedCells(boardSize);
                if (blackCounter > currentBlackCounter)
                {
                    usedRows.Add(i);
                    return true;
                }
                else if (currentBlackCells > connectedBlackCells && blackCounter >= currentBlackCounter)
                {
                    usedRows.Add(i);
                    return true;
                }
                else
                {
                    InvertRow(i, boardSize);
                }
            }
        }

        for (int i = 0; i < boardSize; i++)
        {
            if (!usedCollumns.Contains(i))
            {
                int currentBlackCounter = blackCounter;
                InvertCollumn(i, boardSize);
                int currentBlackCells = CalculateConnectedCells(boardSize);
                if (blackCounter > currentBlackCounter)
                {
                    usedCollumns.Add(i);
                    return true;
                }
                else if (currentBlackCells > connectedBlackCells && blackCounter >= currentBlackCounter)
                {
                    usedCollumns.Add(i);
                    return true;
                }
                else
                {
                    InvertCollumn(i, boardSize);
                }
            }
        }

        return false;
    }

    private static void InvertCollumn(int collumn, int boardSize)
    {
        for (int i = 0; i < boardSize; i++)
        {
            if (gameBoard[i, collumn] == 'W')
            {
                gameBoard[i, collumn] = 'B';
                blackCounter++;
                whiteCounter--;
            }
            else
            {
                gameBoard[i, collumn] = 'W';
                blackCounter--;
                whiteCounter++;
            }
        }
    }

    private static void InvertRow(int row, int boardSize)
    {
        for (int i = 0; i < boardSize; i++)
        {
            if (gameBoard[row, i] == 'W')
            {
                gameBoard[row, i] = 'B';
                blackCounter++;
                whiteCounter--;
            }
            else
            {
                gameBoard[row, i] = 'W';
                blackCounter--;
                whiteCounter++;
            }
        }
    }

    /// <summary>
    /// The method calculates the number of 
    /// connected black areas with number of 
    /// blocks bigger than 1.
    /// </summary>
    private static int CalculateConnectedCells(int boardSize)
    {
        bool[,] visited = new bool[boardSize, boardSize];
        int blackAreaCounter = 0;
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < gameBoard.GetLength(1); j++)
            {
                if (!visited[i, j] && gameBoard[i, j] == 'B')
                {
                    int changed = 0;
                    DFS(i, j, ref changed, visited);
                    if (changed > 1)
                    {
                        blackAreaCounter++;
                    }
                }
            }
        }

        return blackAreaCounter;
    }

    /// <summary>
    /// A simple DFS based method for marking
    /// the black areas on the gameboard.
    /// </summary>
    private static void DFS(int i, int j, ref int changed, bool[,] visited)
    {
        if (i < 0 || j < 0 || i >= gameBoard.GetLength(0) || j >= gameBoard.GetLength(1))
        {
            return;
        }

        if (gameBoard[i, j] == 'W')
        {
            return;
        }

        if (visited[i, j])
        {
            return;
        }

        visited[i, j] = true;
        changed++;

        DFS(i, j + 1, ref changed, visited);
        DFS(i, j - 1, ref changed, visited);
        DFS(i + 1, j, ref changed, visited);
        DFS(i - 1, j, ref changed, visited);
    }

    private static void CreateGameBoard(int boardSize)
    {
        gameBoard = new char[boardSize, boardSize];
        for (int i = 0; i < boardSize; i++)
        {
            string currentLine = Console.ReadLine();
            for (int j = 0; j < boardSize; j++)
            {
                gameBoard[i, j] = currentLine[j];
                if (currentLine[j] == 'W')
                {
                    whiteCounter++;
                }
                else
                {
                    blackCounter++;
                }
            }
        }
    }
}

