using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TennisGame
{
    class TennisGame
    {
        static void Main(string[] args)
        {
            const int PlaygroundHeight = 50;
            const int PadHeight = 10;
            const char BallSymbol = '*';

            int playerPositionY = 8;

            Random randomGenerator = new Random();
            int ballX = randomGenerator.Next(10, 30);
            int ballY = randomGenerator.Next(10, 30);
            int balldirection = randomGenerator.Next(1, 4);

            Console.CursorVisible = false;
            Console.WindowHeight = PlaygroundHeight;
            Console.BufferHeight = Console.WindowHeight;

            InitializePad(PadHeight, playerPositionY);
            InitializeBall(BallSymbol, ballX, ballY);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        playerPositionY-=2;
                        if (playerPositionY < 0)
                        {
                            playerPositionY = 0;
                        }
                    }

                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        playerPositionY+=2;
                        if (playerPositionY > PlaygroundHeight - PadHeight)
                        {
                            playerPositionY = PlaygroundHeight - PadHeight;
                        }
                    }
                }

                switch (balldirection)
                {
                    case 1:
                        ballX--;
                        ballY--;
                        break;
                    case 2:
                        ballX++;
                        ballY--;
                        break;
                    case 3:
                        ballX++;
                        ballY++;
                        break;
                    case 4:
                        ballX--;
                        ballY++;
                        break;
                    default:
                        break;
                }

                if (ballX == 0)
                {
                    if ((ballY >= playerPositionY) && (ballY <= playerPositionY + 4))
                    {
                        if (balldirection == 1)
                        {
                            balldirection = 2;
                        }
                        else if (balldirection == 4)
                        {
                            balldirection = 3;
                        }
                    }
                    else
                    {
                        Console.WriteLine("GAME OVER");
                    }
                }
                if (ballX == 79)
                {
                    if (balldirection == 2)
                    {
                        balldirection = 1;
                    }
                    else if (balldirection == 3)
                    {
                        balldirection = 4;
                    }
                }
                if (ballY == 0)
                {
                    if (balldirection == 2)
                    {
                        balldirection = 3;
                    }
                    else if (balldirection == 1)
                    {
                        balldirection = 4;
                    }
                }

                if (ballY == 79)
                {
                    if (balldirection == 3)
                    {
                        balldirection = 2;
                    }
                    else if (balldirection == 4)
                    {
                        balldirection = 1;
                    }
                }

                Console.Clear();

                InitializePad(PadHeight, playerPositionY);

                InitializeBall(BallSymbol, ballX, ballY);

                Thread.Sleep(50);
            }
        }

        private static void InitializeBall(char BallSymbol, int ballX, int balY)
        {
            Console.SetCursorPosition(ballX, balY);
            Console.Write(BallSymbol);
        }

        private static void InitializePad(int PadHeight, int playerPositionY)
        {
            for (int i = 0; i < PadHeight; i++)
            {
                Console.SetCursorPosition(0, playerPositionY + i);
                Console.Write("|");
            }
        }
    }
}
