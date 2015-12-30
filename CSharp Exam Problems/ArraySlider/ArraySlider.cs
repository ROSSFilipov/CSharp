using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

class ArraySlider
{
    static void Main(string[] args)
    {
        BigInteger[] array = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();
        string[] input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        int position = 0;
        while (input[0] != "stop")
        {
            int offset = int.Parse(input[0]);
            char operation = char.Parse(input[1]);
            int operand = int.Parse(input[2]);

            position = (position + offset) % array.Length;

            //if (offset < 0)
            //{
            //    position = array.Length - (Math.Abs(position + offset) % array.Length);
            //}
            if (position < 0)
            {
                position += array.Length;
            }

            switch (operation)
            {
                case '&': array[position] &= operand;
                    break;
                case '|': array[position] |= operand;
                    break;
                case '^': array[position] ^= operand;
                    break;
                case '+': array[position] += operand;
                    break;
                case '-': array[position] -= operand;
                    if (array[position] < 0)
                    {
                        array[position] = 0;
                    }
                    break;
                case '*': array[position] *= operand;
                    break;
                case '/': array[position] /= operand;
                    break;
                default:
                    break;
            }
            input = Console.ReadLine().Split();
        }
        Console.WriteLine("[{0}]", String.Join(", ", array));
    }
}

