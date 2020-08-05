using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikulden_s_meals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Guest> peoples = new List<Guest>();
            int unlikedMealCount = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Contains("Stop"))
                {
                    break;
                }
                //•	"Like-{guest}-{mea1}":
                var comand = input.Split("-");

                if (input.Contains("Like"))
                {

                    string guest = comand[1];
                    string meal = comand[2];
                    var guests = peoples.Where(x => x.Name == guest).FirstOrDefault();
                    if (guests == null)
                    {
                        Guest people = new Guest(guest, new List<string>());
                        people.Name = guest;
                        people.Meal.Add(meal);
                        peoples.Add(people);

                    }
                    else
                    {

                        if (!guests.CheckMeal(meal))
                        {
                            guests.Meal.Add(meal);
                        }
                    }
                }
                //•	"Unlike-{guest}-{meal}":
                if (input.Contains("Unlike"))
                {
                    string guest = comand[1];
                    string meal = comand[2];
                    var guests = peoples.Where(x => x.Name == guest).FirstOrDefault();

                    if (guests == null)
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else if (!guests.CheckMeal(meal))
                    {
                        Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");

                    }
                    else
                    {
                        unlikedMealCount++;
                        Console.WriteLine($"{guest} doesn't like the {meal}.");
                        guests.Meal.Remove(meal);
                    }

                }
            }
            var sortedList = peoples.OrderBy(n => n.Name);
            foreach (var item in sortedList)
            {
                Console.WriteLine($"{item.Name}: {string.Join(", ", item.PrintListMealDescending())}");
            }
            Console.WriteLine($"Unliked meals: {unlikedMealCount}");
        }
    }

    class Guest
    {
        public string Name { get; set; }
        public List<string> Meal { get; set; }
        public Guest(string name, List<string> meal)
        {
            this.Name = name;
            this.Meal = meal;
        }
        public bool CheckMeal(string meal)
        {
            if (Meal.Contains(meal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<string> PrintListMealDescending()
        {
            var sorted = Meal.OrderByDescending(x=>x).ToList();
            return sorted;
        }
    }
}
