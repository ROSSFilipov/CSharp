using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

class ChatLogger
{
    static void Main(string[] args)
    {
        string[] initialDate = Console.ReadLine().Split();
        DateTime now = ValidateDate(initialDate);

        var chatData = new Dictionary<DateTime, string>();

        StringBuilder builder = new StringBuilder();
        while (true)
        {
            string input = Console.ReadLine();

            if (input == "END")
            {
                break;
            }

            builder.AppendLine(input);
        }

        Regex pattern = new Regex(@"(.*?)\s\/\s([\d\s-:]+)");

        MatchCollection inputCollection = pattern.Matches(builder.ToString());

        foreach (Match item in inputCollection)
        {
            string chatMessage = item.Groups[1].Value.Trim();
            string[] dateDetails = item.Groups[2].Value.Trim().Split();
            DateTime messageDate = ValidateDate(dateDetails);

            chatData.Add(messageDate, chatMessage);
        }

        var orderedChatData = chatData.OrderBy(x => x.Key);

        StringBuilder sb = new StringBuilder();
        foreach (var item in orderedChatData)
        {
            if (item.Key < now)
            {
                sb.Append("<div>");
                sb.Append(item.Value);
                sb.AppendLine("</div>");
            }
        }

        DateTime last = chatData.Keys.Max();

        string lastActive = string.Empty;

        if (last.AddMinutes(1) > now)
        {
            lastActive = "a few moments ago";
        }
        else if (last.AddHours(1) > now)
        {
            lastActive = "minute(s) ago";
        }
        else if (last.AddDays(1).Day == now.Day - 1)
        {
            lastActive = "hour(s) ago";
        }
        else if (last.AddDays(2) > now)
        {
            lastActive = "yesterday";
        }
        else
        {
            lastActive = string.Format("{0}-{1}-{2}", last.Day, last.Month, last.Year);
        }

        sb.Append("<p>Last active: <time>");
        sb.Append(lastActive);
        sb.Append("</time></p>");

        Console.WriteLine(sb.ToString());
    }

    private static DateTime ValidateDate(string[] initialDate)
    {
        string[] ddMMYYY = initialDate[0].Split('-');
        string[] hhMMSS = initialDate[1].Split(':');

        int year = int.Parse(ddMMYYY[2]);
        int month = int.Parse(ddMMYYY[1]);
        int day = int.Parse(ddMMYYY[0]);

        int hour = int.Parse(hhMMSS[0]);
        int minutes = int.Parse(hhMMSS[1]);
        int seconds = int.Parse(hhMMSS[2]);

        return new DateTime(year, month, day, hour, minutes, seconds);
    }
}

