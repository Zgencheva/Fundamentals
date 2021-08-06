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
            Dictionary<string, Dictionary<int, int>> cars = new Dictionary<string, Dictionary<int, int>>();
            //{car}|{mileage}|{fuel}
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|").ToArray();
                string car = input[0];
                int mileage = int.Parse(input[1]);
                int fuel = int.Parse(input[2]);
                //to check if dictinary key is unique!!!
                cars.Add(car, new Dictionary<int, int>());
                cars[car].Add(mileage, fuel);

            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Stop")
                {
                    break;
                }
                string[] cmd = command.Split(" : ").ToArray();
                string action = cmd[0];
                if (action == "Drive")
                {
                    string carDriven = cmd[1];
                    int distance = int.Parse(cmd[2]);
                    int fuel = int.Parse(cmd[3]);
                    int currentCarMilleage = cars[carDriven].Keys.First();
                    if (fuel > cars[carDriven][currentCarMilleage])
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        int newMilleage = currentCarMilleage + distance;
                        int newFuel = cars[carDriven][currentCarMilleage] - fuel;
                        cars[carDriven].Remove(currentCarMilleage);
                        cars[carDriven].Add(newMilleage, newFuel);
                        Console.WriteLine($"{carDriven} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        if (cars[carDriven].Keys.First() >= 100000)
                        {
                            cars.Remove(carDriven);
                            Console.WriteLine($"Time to sell the {carDriven}!");
                        }
                    }
                }
                else if (action == "Refuel")
                {
                    string carDriven = cmd[1];
                    int fuel = int.Parse(cmd[2]);
                    int currentMileage = cars[carDriven].Keys.First();
                    int currentFuel = cars[carDriven][currentMileage];
                    int fueledCharged = 0;
                    if (currentFuel + fuel > 75)
                    {
                        fueledCharged = 75 - currentFuel;
                        cars[carDriven][currentMileage] = 75;
                    }
                    else
                    {
                        cars[carDriven][currentMileage] += fuel;
                        fueledCharged = fuel;
                    }
                    Console.WriteLine($"{carDriven} refueled with {fueledCharged} liters");
                }
                else if (action == "Revert")
                {
                    string carDriven = cmd[1];
                    int kilometers = int.Parse(cmd[2]);
                    int currentCarMileage = cars[carDriven].Keys.First();
                    int currentFuel = cars[carDriven][currentCarMileage];
                    int updated = currentCarMileage - kilometers;
                    if (currentCarMileage - kilometers >= 10000)
                    {
                        cars[carDriven].Remove(currentCarMileage);
                        cars[carDriven].Add(updated, currentFuel);
                        Console.WriteLine($"{carDriven} mileage decreased by {kilometers} kilometers");
                    }
                    else
                    {
                        cars[carDriven].Remove(currentCarMileage);
                        cars[carDriven].Add(10000, currentFuel);
                    }
                }
            }

            //Upon receiving the "Stop" command you need to print all cars in your possession,
            //sorted by their mileage in decscending order, then by their name in ascending order, in the following format:
            //"{car} -> Mileage: {mileage} kms, Fuel in the tank: {fuel} lt."

            foreach (var car in cars.OrderByDescending(x => x.Value.Keys.First()).ThenBy(y=> y.Key))
            {
               
                foreach (var ints in car.Value)
                {
                  Console.WriteLine($"{car.Key} -> Mileage: {ints.Key} kms, Fuel in the tank: {ints.Value} lt.");
               }
                
            }
        }
    }
}
