using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KukataIsDancing
{
    class KukataIsDancing
    {
        //0 - vertical, 1 - horizontal direction
        private static string direction = "UP";

        private static int X = 1;
        private static int Y = 1;

        static string[,] cube = new string[,]
            {
                {"RED", "BLUE", "RED"},
                {"BLUE", "GREEN", "BLUE"},
                {"RED", "BLUE", "RED"}
            };

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] dances = new string[n];

            for (int i = 0; i < n; i++)
            {
                dances[i] = Console.ReadLine().Trim();
            }

            ExecuteDancing(dances, n);
        }

        private static void ExecuteDancing(string[] dances, int n)
        {
            for (int i = 0; i < dances.Length; i++)
            {
                string currentDance = dances[i];
                for (int j = 0; j < currentDance.Length; j++)
                {
                    switch (currentDance[j])
                    {
                        case 'L': TurnLeft();
                            break;
                        case 'R': TurnRight();
                            break;
                        case 'W': ExecuteMove();
                            break;
                        default:
                            break;
                    }
                }

                Console.WriteLine(cube[X, Y]);
                X = 1;
                Y = 1;
                direction = "UP";
            }
        }

        private static void ExecuteMove()
        {
            switch (direction)
            {
                case "UP": 
                    X--;
                    if (X < 0)
                    {
                        X = 2;
                    }
                    break;
                case "DOWN":
                    X++;
                    if (X >= 3)
                    {
                        X = 0;
                    }
                    break;
                case "LEFT":
                    Y--;
                    if (Y < 0)
                    {
                        Y = 2;
                    }
                    break;
                case "RIGHT":
                    Y++;
                    if (Y >= 3)
                    {
                        Y = 0;
                    }
                    break;
                default:
                    break;
            }
        }

        private static void TurnLeft()
        {
            switch (direction)
            {
                case "UP": direction = "LEFT";
                    break;
                case "DOWN": direction = "RIGHT";
                    break;
                case "LEFT": direction = "DOWN";
                    break;
                case "RIGHT": direction = "UP";
                    break;
                default:
                    break;
            }
        }

        private static void TurnRight()
        {
            switch (direction)
            {
                case "UP": direction = "RIGHT";
                    break;
                case "DOWN": direction = "LEFT";
                    break;
                case "LEFT": direction = "UP";
                    break;
                case "RIGHT": direction = "DOWN";
                    break;
                default:
                    break;
            }
        }
    }
}
