using System;
using System.Text;
using System.Text.RegularExpressions;

namespace BossRush
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\|[A-Z]{4,}\|):(#[a-zA-Z]+ [a-zA-Z]+#)";
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                string input = Console.ReadLine();
                Match matches = Regex.Match(input, pattern);
                if (matches.Success)
                {
                    StringBuilder name = new StringBuilder();
                    var bossName = matches.Groups[1].ToString().ToCharArray();
                    foreach (var item in bossName)
                    {
                        if (Char.IsLetter(item))
                        {
                            name.Append(item);
                        }
                    }
                    var title = matches.Groups[2].ToString().Split();
                    var array = title[0].ToCharArray();
                    var secondArray = title[1].ToCharArray();

                    StringBuilder bossTitle = new StringBuilder();
                    StringBuilder bossTitle1 = new StringBuilder();
                    foreach (var item in array)
                    {
                        if (Char.IsLetter(item))
                        {
                            bossTitle.Append(item);
                        }
                    }
                    foreach (var item in secondArray)
                    {
                        if (Char.IsLetter(item))
                        {
                            bossTitle1.Append(item);
                        }
                    }
                    int count = (bossTitle.Length + bossTitle1.Length) + 1;
                    Console.WriteLine($"{name.ToString()}, The {bossTitle.ToString()} {bossTitle1.ToString()}");
                    Console.WriteLine($">> Strength: {name.Length}");
                    Console.WriteLine($">> Armour: {count}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
    }
}
