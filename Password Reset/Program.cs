using System;
using System.Linq;
using System.Text;

namespace Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                var comand = Console.ReadLine().Split();
                if (comand.Contains("Done"))
                {
                    break;
                }
                if (comand.Contains("TakeOdd"))
                {
                    StringBuilder password = new StringBuilder();

                    for (int i = 1; i < input.Length; i += 2)
                    {
                        password.Append(input[i]);
                    }
                    input = password.ToString();
                    Console.WriteLine(input);
                }
                if (comand.Contains("Cut"))
                {

                    int index = int.Parse(comand[1]);
                    int lenght = int.Parse(comand[2]);
                    string substr = input.Substring(index, lenght);
                    int st = input.IndexOf(substr);
                    input = input.Remove(index, substr.Length);
                    Console.WriteLine(input);
                }
                if (comand.Contains("Substitute"))
                {
                    string substring = comand[1];
                    string substitute = comand[2];
                    if (!input.Contains(substring))
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                    else
                    {
                        input = input.Replace(substring, substitute);
                        Console.WriteLine(input);
                    }
                }
            }
            Console.WriteLine($"Your password is: {input}");
        }
    }
}
