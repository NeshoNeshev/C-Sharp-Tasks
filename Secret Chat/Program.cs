using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            StringBuilder sb = new StringBuilder(message);
            while (true)
            {
                List<string> input = Console.ReadLine().Split(":|:").ToList();
                string comand = input[0];
                if (comand == "Reveal")
                {
                    break;
                }
                if (comand == "ChangeAll")
                {
                    string substring = input[1];
                    string replacement = input[2];
                    sb.Replace(substring, replacement);
                    Console.WriteLine(sb);
                }
                if (comand == "Reverse")
                {
                    string subs = input[1];
                    string replay = subs;
                    int index = sb.ToString().IndexOf(subs);
                    if (index == -1)
                    {
                        Console.WriteLine("error");

                    }
                    else
                    {
                        char[] array = subs.ToCharArray();
                        Array.Reverse(array);
                        replay = new String(array);
                        sb.Remove(index, subs.Length);
                        sb.Append(replay);
                        Console.WriteLine(sb);
                    }

                }
                if (comand == "InsertSpace")
                {
                    string num = input[1];
                    int number = int.Parse(num);
                    sb.Insert(number, " ");
                    Console.WriteLine(sb);
                }
            }
            Console.WriteLine($"You have a new text message: {sb}");
        }
    }
}
