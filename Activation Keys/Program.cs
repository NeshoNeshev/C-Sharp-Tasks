using System;
using System.Linq;
using System.Text;

namespace Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (true)
            {

                var comand = Console.ReadLine().Split(">>>");
                if (comand.Contains("Generate"))
                {
                    break;
                }
                StringBuilder sb = new StringBuilder(text);
                if (comand.Contains("Contains"))
                {
                    var substring = comand[1];
                    if (text.Contains(comand[1]))
                    {
                        Console.WriteLine($"{text} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                //Flip >>> Upper / Lower >>>{ startIndex}>>>{ endIndex}
                if (comand.Contains("Flip"))
                {
                    int startIndex = int.Parse(comand[2]);
                    int endIndex = int.Parse(comand[3]);
                    //StringBuilder sb = new StringBuilder(text);
                    if (comand.Contains("Upper"))
                    {
                        int last = endIndex - startIndex;
                        string replace = text.Substring(startIndex, last);
                        string upper = replace.ToUpper();
                        sb.Replace(replace, upper);
                        text = sb.ToString();
                        Console.WriteLine(text);

                    }
                    if (comand.Contains("Lower"))
                    {
                        int last = endIndex - startIndex;
                        string replace = text.Substring(startIndex, last);
                        string lower = replace.ToLower();
                        sb.Replace(replace, lower);
                        text = sb.ToString();
                        Console.WriteLine(text);
                    }
                }
                //•	Slice >>>{ startIndex}>>>{ endIndex}
                if (comand.Contains("Slice"))
                {
                    int startIndex = int.Parse(comand[1]);
                    int endIndex = int.Parse(comand[2]);
                    int last = endIndex - startIndex;
                    sb.Remove(startIndex, last);
                    text = sb.ToString();
                    Console.WriteLine(text);
                }
            }
            Console.WriteLine($"Your activation key is: {text}");
        }
    }
}
