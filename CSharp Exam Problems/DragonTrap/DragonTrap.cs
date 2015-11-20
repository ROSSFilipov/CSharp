using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonTrap
{
    class DragonTrap
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> matrixCols = new List<string>();

            for (int i = 0; i < n; i++)
            {
                matrixCols.Add(Console.ReadLine());
            }

            char[,] originalMatrix = new char[n, matrixCols[0].Length];

            FillMatrix(originalMatrix, matrixCols, n);

            char[,] newMatrix = originalMatrix;

            while (true)
            {
                string currentCommand = Console.ReadLine();

                if (currentCommand == "End")
                {
                    break;
                }

                int[] numbers = currentCommand
                    .Split(new char[] { ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int radius = numbers[2];
                int startX = numbers[0] - radius;
                int endX = numbers[0] + radius;
                int startY = numbers[1] - radius;
                int endY = numbers[1] + radius;
                int rotations = numbers[3];

                List<Tuple<int, int>> currentCharacters = new List<Tuple<int, int>>();

                CollectCharacters(currentCharacters, newMatrix, startX, endX, startY, endY);

                if (rotations < 0)
                {
                    RotateCounterClockwise(newMatrix, currentCharacters, rotations);
                }
                else
                {
                    RotateClockwise(newMatrix, currentCharacters, rotations);
                }
            }

            PrintOutput(newMatrix, originalMatrix);
        }

        private static void RotateCounterClockwise(char[,] newMatrix, List<Tuple<int, int>> currentCharacters, int rotations)
        {
            char[] charArray = new char[currentCharacters.Count];

            for (int i = 0; i < charArray.Length; i++)
            {
                charArray[i] = newMatrix[currentCharacters[i].Item1, currentCharacters[i].Item2];
            }

            char[] rotatedChars = new char[charArray.Length];

            for (int i = 0; i < rotatedChars.Length; i++)
            {
                rotatedChars[i] = charArray[(i + rotations) % charArray.Length];
            }

            PlaceNewCharacters(newMatrix, rotatedChars, currentCharacters);
        }

        private static void RotateClockwise(char[,] newMatrix, List<Tuple<int, int>> currentCharacters, int rotations)
        {
            char[] charArray = new char[currentCharacters.Count];

            for (int i = 0; i < charArray.Length; i++)
            {
                charArray[i] = newMatrix[currentCharacters[i].Item1, currentCharacters[i].Item2];
            }

            char[] rotatedChars = new char[charArray.Length];

            for (int i = 0; i < rotatedChars.Length; i++)
            {
                int position = (i - rotations) % charArray.Length;
                if (position < 0)
                {
                    position += charArray.Length;
                }
                rotatedChars[i] = charArray[position];
            }

            PlaceNewCharacters(newMatrix, rotatedChars, currentCharacters);
        }

        private static void PlaceNewCharacters(char[,] newMatrix, char[] rotatedChars, List<Tuple<int, int>> currentCharacters)
        {
            for (int i = 0; i < rotatedChars.Length; i++)
            {
                newMatrix[currentCharacters[i].Item1, currentCharacters[i].Item2] = rotatedChars[i];
            }
        }

        private static void FillMatrix(char[,] matrix, List<string> matrixCols, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string currentLine = matrixCols[i];
                for (int j = 0; j < currentLine.Length; j++)
                {
                    matrix[i, j] = currentLine[j];
                }
            }
        }

        private static void CollectCharacters(List<Tuple<int, int>> currentCharacters, char[,] newMatrix, int startX, int endX, int startY, int endY)
        {
            int X = startX;
            int Y = endY;

            while (X < endX)
            {
                if (IsInsideMatrix(X, Y, newMatrix))
                {
                    currentCharacters.Add(new Tuple<int, int>(X, Y));
                }
                X++;
            }

            while (Y > startY)
            {
                if (IsInsideMatrix(X, Y, newMatrix))
                {
                    currentCharacters.Add(new Tuple<int, int>(X, Y));
                }
                Y--;
            }

            while (X > startX)
            {
                if (IsInsideMatrix(X, Y, newMatrix))
                {
                    currentCharacters.Add(new Tuple<int, int>(X, Y));
                }
                X--;
            }

            while (Y < endY)
            {
                if (IsInsideMatrix(X, Y, newMatrix))
                {
                    currentCharacters.Add(new Tuple<int, int>(X, Y));
                }
                Y++;
            }
        }

        private static bool IsInsideMatrix(int X, int Y, char[,] newMatrix)
        {
            bool isInside =
                X >= 0 &&
                X < newMatrix.GetLength(0) &&
                Y >= 0 &&
                Y < newMatrix.GetLength(1);

            return isInside;
        }

        private static void PrintOutput(char[,] newMatrix, char[,] originalMatrix)
        {
            int changedSymbolsCounter = 0;

            for (int i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < newMatrix.GetLength(1); j++)
                {
                    if (originalMatrix[i, j] != newMatrix[i, j])
                    {
                        changedSymbolsCounter++;
                    }

                    Console.Write(newMatrix[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine("Symbols changed: {0}", changedSymbolsCounter);
        }
    }
}
