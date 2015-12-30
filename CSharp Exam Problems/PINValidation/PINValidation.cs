using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class PINValidation
{
    private static int[] numbers = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

    static void Main(string[] args)
    {
        string[] names = Console.ReadLine().Trim().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        string gender = Console.ReadLine().Trim();
        string PIN = Console.ReadLine().Trim();

        if (!IsValidName(names) || !IsValidGender(gender) || !IsValidPIN(PIN, gender))
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
        }
        else
        {
            Console.WriteLine("{{\"name\":\"{0}\",\"gender\":\"{1}\",\"pin\":\"{2}\"}}", string.Join(" ", names), gender, PIN);
        }
    }

    private static bool IsValidPIN(string PIN, string gender)
    {
        bool isValid = true;
        string year = PIN.Substring(0, 6);
        string regionalNumber = PIN.Substring(6, 3);
        int genderNumber = int.Parse(PIN.Substring(8, 1));
        int checksum = int.Parse(PIN.Substring(9, 1));

        int[] PINNumbers = new int[PIN.Length];

        for (int i = 0; i < PINNumbers.Length; i++)
        {
            PINNumbers[i] = int.Parse(PIN[i].ToString());
        }

        if (!((gender == "female" && genderNumber % 2 != 0) || (gender == "male" && genderNumber % 2 == 0)))
        {
            isValid = false;
        }

        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i] * PINNumbers[i];
        }

        if (sum % 11 != checksum)
        {
            isValid = false;
        }

        return isValid;
    }

    private static bool IsValidGender(string gender)
    {
        bool isValid = true;

        if (gender != "male" && gender != "female")
        {
            isValid = false;
        }

        return isValid;
    }

    private static bool IsValidName(string[] names)
    {
        bool isValid = true;

        Regex namePattern = new Regex("[A-Z][a-z]+");

        if (!namePattern.IsMatch(names[0]) || !namePattern.IsMatch(names[1]) || names.Length != 2)
        {
            isValid = false;
        }

        return isValid;
    }
}

