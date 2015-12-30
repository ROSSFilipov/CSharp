using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class SemanticHTML
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        StringBuilder sb = new StringBuilder();

        while (input != "END")
        {
            if (input.Contains("<div"))
            {
                Regex replace = new Regex("(\\s*)<(div).*((id|class)\\s*=\\s*\"(.*?)\").*(?=>)");
                Match replacement = replace.Match(input);
                input = replacement.Value;
                input = input.Replace(replacement.Groups[2].Value, replacement.Groups[5].Value);
                input = input.Replace(replacement.Groups[3].Value, " ");
                input = Regex.Replace(input.Trim(), "\\s+", " ");
                input = replacement.Groups[1].Value + input + ">";
                sb.Append(input);
                sb.AppendLine();
            }
            else if (input.Contains("</div"))
            {
                Regex replace = new Regex("(\\s*)<\\/div>\\s.*?(\\w+)\\s*-->");
                Match replacement = replace.Match(input);
                input = replacement.Groups[1].Value + "</" + replacement.Groups[2].Value + ">";
                sb.Append(input);
                sb.AppendLine();
            }
            else
            {
                sb.Append(input);
                sb.AppendLine();
            }
            input = Console.ReadLine();
        }

        string final = sb.ToString();
        Console.WriteLine(final);
    }
}

