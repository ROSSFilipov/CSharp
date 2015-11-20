using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeStuff
{
    class OfficeStuff
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> nestedDict = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] inputSplit = input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                string companyName = inputSplit[0];
                string product = inputSplit[2];
                int amount = int.Parse(inputSplit[1]);

                if (!nestedDict.ContainsKey(companyName))
                {
                    nestedDict.Add(companyName, new Dictionary<string,int>());
                    nestedDict[companyName].Add(product, amount);
                }
                else
                {
                    if (!nestedDict[companyName].ContainsKey(product))
                    {
                        nestedDict[companyName].Add(product, amount);
                    }
                    else
                    {
                        nestedDict[companyName][product] += amount;
                    }
                }
            }

            var sorting = nestedDict.OrderBy(x => x.Key);
            foreach (var pair in sorting)
            {
                Console.Write("{0}: ", pair.Key);
                List<string> tempList = new List<string>();
                foreach (var item in pair.Value)
                {
                    tempList.Add(item.Key + "-" + item.Value);
                }
                Console.WriteLine("{0}", String.Join(", ", tempList));
            }
        }
    }
}
