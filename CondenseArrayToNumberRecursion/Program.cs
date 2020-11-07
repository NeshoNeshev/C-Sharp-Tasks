using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int result = CondenseArrayToNumber(numbers,numbers.Length);

            Console.WriteLine(result);

        }
        //array of integers and condens them by summing adjacent couples of elements until a single integer is obtained
        public static int CondenseArrayToNumber(int[] numbers,int count   )
        {
            int sum = numbers[0];
            if (count==0)
            {
                return sum;
            }
            for (int i = 0; i < count - 1; i++)
            {
                numbers[i] = numbers[i] + numbers[i + 1];
            }

            count--;
            return CondenseArrayToNumber(numbers,count);
        }
    }
}
