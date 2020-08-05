using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Cars> carsSpecification = new List<Cars>();
            for (int i = 0; i < n; i++)
            {
                var cars = Console.ReadLine().Split("|");
                string name = cars[0];
                int mile = int.Parse(cars[1]);
                int fuel = int.Parse(cars[2]);
                Cars carsModel = new Cars(name, mile, fuel);
                if (!carsModel.CarName.Contains(name))
                {
                    carsModel.CarName = name;
                    carsModel.Miles = mile;
                    carsModel.Fuel = fuel;
                }
                carsSpecification.Add(carsModel);
            }
            while (true)
            {
                string comand = Console.ReadLine();
                if (comand.Contains("Stop"))
                {
                    break;
                }
                string[] cars = comand.Split(" : ");
                if (comand.Contains("Drive"))
                {
                    string car = cars[1];
                    int km = int.Parse(cars[2]);
                    int fuel = int.Parse(cars[3]);
                    Cars currCar = carsSpecification.Where(x => x.CarName == car).FirstOrDefault();
                    if (currCar.Fuel - fuel <= 0)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        currCar.Miles += km;
                        currCar.Fuel -= fuel;
                        Console.WriteLine($"{car} driven for {km} kilometers. {fuel} liters of fuel consumed.");
                    }
                    if (currCar.Miles >= 100_000)
                    {
                        Console.WriteLine($"Time to sell the {car}!");
                        carsSpecification.Remove(currCar);
                    }
                }
                if (comand.Contains("Refuel"))
                {
                    string car = cars[1];
                    int fuel = int.Parse(cars[2]);
                    Cars currCar = carsSpecification.Where(x => x.CarName == car).FirstOrDefault();
                    if ((currCar.Fuel + fuel) > 75)
                    {
                        fuel = 75 - currCar.Fuel;
                        currCar.Fuel = 75;
                    }
                    else
                    {
                        currCar.Fuel += fuel;
                    }
                    Console.WriteLine($"{car} refueled with {fuel} liters");
                }
                if (comand.Contains("Revert"))
                {
                    string car = cars[1];
                    int km = int.Parse(cars[2]);
                    Cars currCar = carsSpecification.Where(x => x.CarName == car).FirstOrDefault();
                    if (currCar.Miles - km >= 10_000)
                    {
                        currCar.Miles -= km;
                        Console.WriteLine($"{car} mileage decreased by {km} kilometers");
                    }
                    else
                    {
                        currCar.Miles = 10_000;
                    }
                }
            }
            var sortedList = carsSpecification.OrderByDescending(m => m.Miles).ThenBy(n => n.CarName);
            foreach (var item in sortedList)
            {
                Console.WriteLine($"{item.CarName} -> Mileage: {item.Miles} kms, Fuel in the tank: {item.Fuel} lt.");
            }
        }
    }
    public class Cars
    {
        public string CarName { get; set; }
        public int Miles { get; set; }
        public int Fuel { get; set; }
        public Cars(string carName, int mileage, int fuel)
        {
            this.CarName = carName;
            this.Miles = mileage;
            this.Fuel = fuel;
        }
    }
}
