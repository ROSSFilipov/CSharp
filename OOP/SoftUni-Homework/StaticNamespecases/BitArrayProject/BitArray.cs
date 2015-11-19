using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BitArrayProject
{
    public class BitArray
    {
        private const int maxValue = 100000;

        private int[] bitSequence;

        public BitArray(int numberOfBits)
        {
            this.initializeBitSequence(numberOfBits);
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 100000)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }

                return this.bitSequence[index];
            }
            set
            {
                this.SetBit(index, value);
            }
        }

        private void SetBit(int index, int value)
        {
            this.bitSequence[this.bitSequence.Length - 1 - index] = value;
        }

        private void initializeBitSequence(int numberOfBits)
        {
            if (numberOfBits < 0 || numberOfBits > 100000)
            {
                throw new ArgumentOutOfRangeException("");
            }

            this.bitSequence = new int[numberOfBits];
        }

        public override string ToString()
        {
            //int[] tempArray = new int[this.bitSequence.Length];
            BigInteger result = 0;

            for (int i = 0; i < this.bitSequence.Length; i++)
            {
                if (this.bitSequence[this.bitSequence.Length - 1 - i] == 1)
                {
                    //tempArray[this.bitSequence.Length - 1 - i] += ManualMultiplification(i); 
                    result += ManualMultiplification(i);
                }
            }

            //return string.Join("", tempArray);
            return result.ToString();
        }

        private BigInteger ManualMultiplification(int i)
        {
            if (i == 0)
            {
                return 1;
            }

            BigInteger result = 1;
            for (int j = 0; j < i; j++)
            {
                result *= 2;
            }

            return result;
        }
    }
}
