using System;

namespace Nikulden_s_Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Contains("Finish"))
                {
                    break;
                }
                var comand = input.Split();
                //•	"Replace {currentChar} {newChar}"
                if (input.Contains("Replace"))
                {
                    char curentChar = char.Parse(comand[1]);
                    char newChar = char.Parse(comand[2]);
                    if (text.Contains(curentChar))
                    {
                        text = text.Replace(curentChar, newChar);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        continue;
                    }
                }
                //•	"Cut {startIndex} {endIndex}"
                if (input.Contains("Cut"))
                {

                    int startIndex = int.Parse(comand[1]);
                    int endIndex = int.Parse(comand[2]);
                    if ((startIndex < text.Length && startIndex >=0) && (endIndex <= text.Length && endIndex > 0))
                    {
                        text = text.Remove(startIndex, endIndex);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
                //•	"Make {Upper/Lower}"
                if (input.Contains("Make"))
                {
                    string com = comand[1];
                    if (com== "Upper")
                    {
                        text = text.ToUpper();
                        Console.WriteLine(text);
                    }
                    if (com == "Lower")
                    {
                        text = text.ToLower();
                        Console.WriteLine(text);
                    }
                }
                //•	"Check" {string}
                if (input.Contains("Check"))
                {
                    string check = comand[1];
                    if (text.Contains(check))
                    {
                        Console.WriteLine($"Message contains {check}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {check}");
                    }
                }
                //•	"Sum {startIndex} {endIndex}"
                if (input.Contains("Sum"))
                {
                    int startIndex = int.Parse(comand[1]);
                    int endIndex = int.Parse(comand[2]);
                    if ((startIndex < text.Length  && startIndex >= 0) && (endIndex <= text.Length && endIndex > 0))
                    {
                        var substring = text.Substring(startIndex,endIndex).ToCharArray();
                        int sum = 0;
                        for (int i = 0; i < substring.Length; i++)
                        {
                            sum += (int)substring[i];
                        }
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
            }
        }
    }
}
