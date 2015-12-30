using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class DragonSharp
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<string> outputList = new List<string>();
        Regex splitPattern = new Regex("out");
        Regex quotePatterns = new Regex("\"(.*?)\"\\s*?(;)$");
        Regex bracketMatch = new Regex("([0-9]+)(==|<|>)([0-9]+)");

        int errorLine = 0;
        bool currentStatement = true;
        for (int i = 0; i < n; i++)
        {
            string currentInput = Console.ReadLine();

            string[] lineSplit = splitPattern.Split(currentInput);

            Match quoteMatch = quotePatterns.Match(lineSplit[1]);

            if (quoteMatch.Groups.Count < 2)
            {
                errorLine = i + 1;
                outputList.Clear();
                break;
            }
            else
            {
                string toBePrinted = quoteMatch.Groups[1].Value;
                string conditionalStatement = lineSplit[0];

                string[] conditionalSplit = lineSplit[0]
                    .Split(new char[] { ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

                if (conditionalSplit[0] == "if")
                {
                    string bracketStatement = conditionalSplit[1];
                    Match bracketSplit = bracketMatch.Match(bracketStatement);

                    int numberOne = int.Parse(bracketSplit.Groups[1].ToString());
                    int numberTwo = int.Parse(bracketSplit.Groups[3].ToString());
                    string bracketOperator = bracketSplit.Groups[2].ToString();

                    if (IsTrueBracketStatement(numberOne, numberTwo, bracketOperator))
                    {
                        if (conditionalSplit.Length > 2)
                        {
                            if (conditionalSplit[2] == "loop")
                            {
                                ExecuteLoops(outputList, toBePrinted, conditionalSplit);
                                currentStatement = true;
                            }
                        }
                        else
                        {
                            outputList.Add(toBePrinted);
                        }
                    }
                    else
                    {
                        currentStatement = false;
                    }
                }
                else
                {
                    if (currentStatement == false)
                    {
                        if (conditionalSplit.Length > 1)
                        {
                            if (conditionalSplit[1] == "loop")
                            {
                                ExecuteLoops(outputList, toBePrinted, conditionalSplit);
                            }
                        }
                        else
                        {
                            outputList.Add(toBePrinted);
                        }
                    }
                }
            }
        }

        if (outputList.Count == 0)
        {
            Console.WriteLine("Compile time error @ line {0}", errorLine);
        }
        else
        {
            foreach (string item in outputList)
            {
                Console.WriteLine(item);
            }
        }
    }

    private static void ExecuteLoops(List<string> outputList, string toBePrinted, string[] conditionalSplit)
    {
        int loops = conditionalSplit.Length == 3 ? int.Parse(conditionalSplit[2]) : int.Parse(conditionalSplit[3]); ;
        for (int i1 = 0; i1 < loops; i1++)
        {
            outputList.Add(toBePrinted);
        }
    }

    private static bool IsTrueBracketStatement(int numberOne, int numberTwo, string bracketOperator)
    {
        switch (bracketOperator)
        {
            case "==":
                if (numberOne == numberTwo)
                {
                    return true;
                }
                break;
            case "<":
                if (numberOne < numberTwo)
                {
                    return true;
                }
                break;
            case ">":
                if (numberOne > numberTwo)
                {
                    return true;
                }
                break;
        }

        return false;
    }
}

