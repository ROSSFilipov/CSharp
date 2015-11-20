using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelevanceIndex
{
    class RelevanceIndex
    {
        static void Main(string[] args)
        {
            string searchWord = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            string[][] newText = new string[n][];

            TakeInput(newText, n);

            FormatText(newText, n, searchWord);

            var paragraphs = new Dictionary<int, string[]>();

            PrintText(newText, n, searchWord, paragraphs);
        }

        private static void TakeInput(string[][] newText, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] currentLine = Console.ReadLine()
                    .Trim()
                    .Split(new char[] { ',', '.', '(', ')', ';', '-', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                newText[i] = currentLine;
            }
        }

        private static void FormatText(string[][] newText, int n, string searchWord)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < newText[i].Length; j++)
                {
                    if (newText[i][j].ToUpper() == searchWord.ToUpper())
                    {
                        newText[i][j] = newText[i][j].ToUpper();
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private static void PrintText(string[][] newText, int n, string searchWord, Dictionary<int, string[]> paragraphs)
        {
            for (int i = 0; i < newText.Length; i++)
            {
                paragraphs.Add(i, newText[i]);
            }

            var sortedParagraphs = paragraphs.OrderByDescending(x => x.Value.Count(y => y.ToUpper() == searchWord.ToUpper()));

            foreach (KeyValuePair<int, string[]> item in sortedParagraphs)
            {
                Console.WriteLine("{0}", string.Join(" ", item.Value));
            }
        }
    }
}
