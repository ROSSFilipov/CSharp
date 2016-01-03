using System;
using System.Collections.Generic;
using System.Linq;

class MatchMaker
{
    static void Main(string[] args)
    {
        //MapSolution();

        MaxFlowSolution();
    }

    private static void MaxFlowSolution()
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, HashSet<string>> maleData = new Dictionary<string, HashSet<string>>();
        Dictionary<string, HashSet<string>> interestsData = new Dictionary<string, HashSet<string>>();
        ReadData(maleData, interestsData, n);
        Solve(maleData, interestsData);
    }

    private static void Solve(Dictionary<string, HashSet<string>> maleData, Dictionary<string, HashSet<string>> interestsData)
    {
        int bestMatches = 0;
        string bestMale = string.Empty;
        string bestFemale = string.Empty;
        foreach (var currentMale in maleData)
        {
            Dictionary<string, int> matches = new Dictionary<string, int>();
            foreach (string currentInterest in currentMale.Value)
            {
                foreach (string currentFemale in interestsData[currentInterest])
                {
                    if (!matches.ContainsKey(currentFemale))
                    {
                        matches.Add(currentFemale, 0);
                    }

                    matches[currentFemale]++;
                    if (matches[currentFemale] > bestMatches)
                    {
                        bestMatches = matches[currentFemale];
                        bestMale = currentMale.Key;
                        bestFemale = currentFemale;
                    }

                    if (matches[currentFemale] == bestMatches && currentMale.Key.CompareTo(bestMale) == -1)
                    {
                        bestMale = currentMale.Key;
                        bestFemale = currentFemale;
                    }
                }
            }
        }

        Console.WriteLine("{0} and {1} have {2} common {3}!",
            bestMale, bestFemale, bestMatches, bestMatches == 1 ? "interest" : "interests");
    }

    private static void ReadData(Dictionary<string, HashSet<string>> maleData, Dictionary<string, HashSet<string>> interestsData, int n)
    {
        for (int i = 0; i < n; i++)
        {
            string currentName = Console.ReadLine();
            string sex = Console.ReadLine();
            int numberOfInterests = int.Parse(Console.ReadLine());
            string[] currentInterests = Console.ReadLine().Split();
            if (sex == "m")
            {
                maleData.Add(currentName, new HashSet<string>());
                maleData[currentName].UnionWith(currentInterests);

                foreach (string interest in currentInterests)
                {
                    if (!interestsData.ContainsKey(interest))
                    {
                        interestsData.Add(interest, new HashSet<string>());
                    }
                }
            }
            else
            {
                foreach (string interest in currentInterests)
                {
                    if (!interestsData.ContainsKey(interest))
                    {
                        interestsData.Add(interest, new HashSet<string>());
                    }

                    interestsData[interest].Add(currentName);
                }
            }
        }
    }

    private static void MapSolution()
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, HashSet<string>> maleData = new Dictionary<string, HashSet<string>>();
        Dictionary<string, HashSet<string>> femaleData = new Dictionary<string, HashSet<string>>();
        for (int i = 0; i < n; i++)
        {
            string currentName = Console.ReadLine();
            string sex = Console.ReadLine();
            int numberOfInterests = int.Parse(Console.ReadLine());
            string[] currentInterests = Console.ReadLine().Split();

            if (sex == "m")
            {
                maleData.Add(currentName, new HashSet<string>());
                maleData[currentName].UnionWith(currentInterests);
            }
            else
            {
                femaleData.Add(currentName, new HashSet<string>());
                femaleData[currentName].UnionWith(currentInterests);
            }
        }

        maleData.OrderByDescending(x => x.Value.Count);
        femaleData.OrderByDescending(x => x.Value.Count);

        string bestMale = string.Empty;
        string bestFemale = string.Empty;
        int numberOfMatches = 0;
        foreach (var currentMale in maleData)
        {
            foreach (var currentFemale in femaleData)
            {
                if (currentMale.Value.Count < numberOfMatches)
                {
                    break;
                }

                int currentMatches = CalculateMatches(maleData, femaleData, currentMale.Key, currentFemale.Key);
                if (currentMatches > numberOfMatches)
                {
                    numberOfMatches = currentMatches;
                    bestMale = currentMale.Key;
                    bestFemale = currentFemale.Key;
                }

                if (currentMatches == numberOfMatches && currentMatches != 0)
                {
                    if (currentMale.Key.CompareTo(bestMale) == -1)
                    {
                        bestMale = currentMale.Key;
                        bestFemale = currentFemale.Key;
                    }
                }
            }
        }

        Console.WriteLine("{0} and {1} have {2} common {3}!",
            bestMale, bestFemale, numberOfMatches, numberOfMatches == 1 ? "interest" : "interests");
    }

    private static int CalculateMatches(Dictionary<string, HashSet<string>> maleData, Dictionary<string, HashSet<string>> femaleData, string currentMale, string currentFemale)
    {
        int counter = 0;

        foreach (var maleInterest in maleData[currentMale])
        {
            foreach (var femaleInterest in femaleData[currentFemale])
            {
                if (maleInterest == femaleInterest)
                {
                    counter++;
                    break;
                }
            }
        }

        return counter;
    }
}

