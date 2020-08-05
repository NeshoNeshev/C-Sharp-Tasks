using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace _3._SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";
            List<PersonProductPrice> persons = new List<PersonProductPrice>();
            double total = 0.0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input== "end of shift")
                {
                    break;
                }
                
                if (Regex.IsMatch(input,pattern))
                {
                    Match match = Regex.Match(input, pattern);
                    var name = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    double quantyty = double.Parse((match.Groups["count"].Value));
                    double price = double.Parse(match.Groups["price"].Value);
                    double totalPrice = quantyty * price;
                    PersonProductPrice person = new PersonProductPrice(name,product,totalPrice);
                    if (!person.Name.Contains(name))
                    {
                        person.Name = name;
                        person.Product = product;
                        person.Price = totalPrice;
                    }
                    persons.Add(person);
                    total += totalPrice;
                }
            }
            foreach (var item in persons)
            {
                Console.WriteLine(item.Print());
            }
            Console.WriteLine($"Total income: {total:f2}");
            
        }
    }
    public class PersonProductPrice
    {
        public string Name { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public PersonProductPrice(string name,string product, double price)
        {
            this.Name = name;
            this.Product = product;
            this.Price = price;
        }
        public string Print()
        {
            return $"{Name}: {Product} - {Price:f2}";
                
        }
    }
}
