using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(!([A-Z][a-z]{2,})!):(\[([A-Za-z]{7,})\])";
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                Match matches = Regex.Match(message, pattern);
                if (matches.Success)
                {
                    string name = matches.Groups[2].ToString();
                    var text = matches.Groups[4].ToString().ToCharArray();
                    List<int> numbers = new List<int>();

                    foreach (var item in text)
                    {
                        numbers.Add((int)item);
                    }
                    Console.WriteLine($"{name}: {string.Join(" ", numbers)}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
