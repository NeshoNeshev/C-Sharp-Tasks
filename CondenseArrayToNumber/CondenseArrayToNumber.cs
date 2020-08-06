using System;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int result = CondenseArrayToNumber(numbers);

            Console.WriteLine(result);  
            
        }
        //array of integers and condens them by summing adjacent couples of elements until a single integer is obtained
        public static int CondenseArrayToNumber(int[] numbers)
        {
            int n = numbers.Length;
            while (n > 0)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    numbers[i] = numbers[i] + numbers[i + 1];
                }

                n--;
            }
            int sum = numbers[0];
            return sum;
        }
    }
    
}
