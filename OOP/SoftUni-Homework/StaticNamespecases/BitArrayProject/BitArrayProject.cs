using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArrayProject
{
    class BitArrayProject
    {
        static void Main(string[] args)
        {
            BitArray array = new BitArray(1000);
            for (int i = 0; i < 1000; i += 2)
            {
                array[i] = 1;
            }
            Console.WriteLine(array);
        }
    }
}
