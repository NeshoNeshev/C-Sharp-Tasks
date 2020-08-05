using System;
using System.Collections.Generic;
using System.Linq;

namespace P_rates
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Citi> cities = new Dictionary<string, Citi>();
            while (true)
            {
                var input = Console.ReadLine().Split("||");
                if (input.Contains("Sail"))
                {
                    break;
                }
                string name = input[0];
                int population = int.Parse(input[1]);
                int gold = int.Parse(input[2]);
                if (!cities.ContainsKey(name))
                {
                    Citi citi = new Citi();
                    citi.Population = population;
                    citi.Gold = gold;
                    cities.Add(name, citi);
                }
                else
                {
                    cities[name].Population += population;
                    cities[name].Gold += gold;
                }
            }
            //•	"Plunder=>{town}=>{people}=>{gold}"
            while (true)
            {
                var comand = Console.ReadLine().Split("=>");
                if (comand.Contains("End"))
                {
                    break;
                }

                string town = comand[1];
                if (comand.Contains("Plunder"))
                {

                    if (cities.ContainsKey(town))
                    {
                        int people = int.Parse(comand[2]);
                        int gold = int.Parse(comand[3]);
                        cities[town].Population -= people;
                        cities[town].Gold -= gold;
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                    }

                }
                if (cities[town].Population <= 0 || cities[town].Gold <= 0)
                {
                    cities.Remove(town);
                    Console.WriteLine($"{town} has been wiped off the map!");
                }
                //•	"Prosper=>{town}=>{gold}"
                if (comand.Contains("Prosper"))
                {

                    if (cities.ContainsKey(town))
                    {
                        int gold = int.Parse(comand[2]);
                        if (gold >= 0)
                        {
                            cities[town].Gold += gold;
                            int totalGold = cities[town].Gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {totalGold} gold.");
                        }
                        else
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                        }

                    }
                }
                if (cities.Count == 0)
                {
                    break;
                }
            }
            if (cities.Count > 0)
            {
                var sortedTowns = cities.OrderByDescending(t => t.Value.Gold).ThenBy(t => t.Key);
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var item in sortedTowns)
                {
                    Console.WriteLine($"{item.Key} -> Population: {item.Value.Population} citizens, Gold: {item.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }

        }
    }
    class Citi
    {
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}
