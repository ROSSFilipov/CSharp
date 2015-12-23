namespace GroupPermutations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class GroupPermutations
    {
        static int inputLength;
        static string[] words;
        static int wordsLength;

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            inputLength = input.Length;

            bool[] used = new bool[inputLength];
            List<string> combinedLetters = new List<string>();

            GenerateCombinedLetters(combinedLetters, input, used);

            wordsLength = combinedLetters.Count;
            words = new string[wordsLength];

            for (int i = 0; i < wordsLength; i++)
            {
                words[i] = combinedLetters[i];
            }

            GeneratePermutations(0);
        }

        /// <summary>
        /// We use the method to create strings with same letters
        /// from the original input and put them into a list. After
        /// we have the list we will generate all permutations which
        /// eventually will run faster.
        /// </summary>
        /// <param name="combinedLetters">The list we will use to save all strings generated from same letters.</param>
        /// <param name="input">The original string input from the console.</param>
        /// <param name="used">An additional boolean array we use to keep track on used letters.</param>
        private static void GenerateCombinedLetters(List<string> combinedLetters, string input, bool[] used)
        {
            for (int i = 0; i < inputLength; i++)
            {
                if (!used[i])
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < inputLength; j++)
                    {
                        if (input[i] == input[j])
                        {
                            sb.Append(input[i]);
                            used[j] = true;
                        }
                    }

                    combinedLetters.Add(sb.ToString());
                }
            }
        }

        /// <summary>
        /// A standart method for generating all permutations of
        /// a given array of strings in this particular case. The
        /// method uses an already assembled array with the strings
        /// we need so we do not have to make additional iterations
        /// to find same letters.
        /// </summary>
        /// <param name="index">The starting index of the array.</param>
        private static void GeneratePermutations(int index)
        {
            if (index >= wordsLength)
            {
                Console.WriteLine(string.Join("", words));
                return;
            }

            for (int i = index; i < wordsLength; i++)
            {
                Swap(index, i);
                GeneratePermutations(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int index, int i)
        {
            if (index == i)
            {
                return;
            }

            string temp = words[i];
            words[i] = words[index];
            words[index] = temp;
        }
    }
}
