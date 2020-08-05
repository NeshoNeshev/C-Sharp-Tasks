using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"(@#+[A-Z][a-zA-Z0-9]{4,}[A-Z]@#+)";

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                bool check = true;
                var input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                if (!match.Success)
                {
                    Console.WriteLine($"Invalid barcode");
                }
                else
                {
                    var barcode = input.ToCharArray();
                    for (int j = 0; j < barcode.Length; j++)
                    {
                        if (Char.IsDigit(barcode[j]))
                        {
                            sb.Append(barcode[j].ToString());
                            check = false;
                        }

                    }
                    if (check)
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {sb}");
                    }
                    sb.Clear();
                }
            }
        }
    }
}
