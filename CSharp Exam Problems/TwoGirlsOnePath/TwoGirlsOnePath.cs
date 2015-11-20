using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TwoGirlsOnePath
{
    class TwoGirlsOnePath
    {
        private static bool gameOverMolly = false;
        private static bool gameOverDolly = false;

        static void Main(string[] args)
        {
            BigInteger[] path = Console.ReadLine()
                .Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse)
                .ToArray();

            BigInteger flowersMolly = 0;
            BigInteger flowersDolly = 0;

            int positionMolly = 0;
            int positionDolly = path.Length - 1;

            CollectFlowers(ref flowersMolly, ref flowersDolly, ref positionMolly, ref positionDolly, path);

            string winner = string.Empty;

            if (gameOverDolly == true && gameOverMolly == true)
            {
                winner = "Draw";
            }
            else
            {
                if (gameOverMolly == true)
                {
                    winner = "Dolly";
                }
                else
                {
                    winner = "Molly";
                }
            }

            Console.WriteLine("{0}", winner);
            Console.WriteLine("{0} {1}", flowersMolly, flowersDolly);
        }

        private static void CollectFlowers(ref BigInteger flowersMolly, ref BigInteger flowersDolly, ref int positionMolly, ref int positionDolly, BigInteger[] path)
        {
            bool isGameOver = false;
            while (!isGameOver)
            {
                if (positionMolly == positionDolly && path[positionMolly] != 0)
                {
                    flowersMolly += path[positionMolly] / 2;
                    flowersDolly += path[positionDolly] / 2;

                    path[positionDolly] = 1;
                }
                else
                {
                    if (path[positionMolly] == 0)
                    {
                        flowersDolly += path[positionDolly];
                        gameOverMolly = true;
                        isGameOver = true;
                        if (path[positionDolly] == 0)
                        {
                            gameOverDolly = true;
                        }
                    }
                    else if (path[positionDolly] == 0)
                    {
                        flowersMolly += path[positionMolly];
                        gameOverDolly = true;
                        isGameOver = true;
                        if (path[positionDolly] == 0)
                        {
                            gameOverDolly = true;
                        }
                    }
                    else
                    {
                        AdjustPositions(ref flowersMolly, ref flowersDolly, ref positionMolly, ref positionDolly, path);
                    }
                }
            }
        }

        private static void AdjustPositions(ref BigInteger flowersMolly, ref BigInteger flowersDolly, ref int positionMolly, ref int positionDolly, BigInteger[] path)
        {
            flowersMolly += path[positionMolly];
            flowersDolly += path[positionDolly];

            BigInteger newPositionMolly = (positionMolly + path[positionMolly]) % path.Length;
            BigInteger newPositionDolly = (positionDolly - path[positionDolly]) % path.Length;

            path[positionMolly] = 0;
            path[positionDolly] = 0;

            positionMolly = (int)newPositionMolly;
            positionDolly = (int)newPositionDolly;

            if (positionDolly < 0)
            {
                positionDolly += path.Length;
            }
        }
    }
}
