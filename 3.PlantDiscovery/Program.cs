using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plants = new List<Plant>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string currPlant = command[0].Trim();
                int rarity = int.Parse(command[1]);
                Plant currentPlant = new Plant(command[0]);
                bool isThereSuchPlant = false;
                foreach (var item in plants)
                {
                    if (item.Name == currPlant)
                    {
                        isThereSuchPlant = true;
                        item.Rarity = rarity;
                    }
                    
                }
                if (isThereSuchPlant == false)
                {
                    plants.Add(currentPlant);
                    currentPlant.Rarity = rarity;
                }
                
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Exhibition")
                {
                    break;
                }
                string[] command = input.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = command[0];
                string[] splitTheCommand = command[1].Split("-", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string currentPlant = splitTheCommand[0].Trim();
                //Plant pl = new Plant(currentPlant);
                //int num = int.Parse(splitTheCommand[1]);
                if (!plants.Any(x=> x.Name == currentPlant))
                {
                    Console.WriteLine("error");
                    continue;
                }
                foreach (var item in plants)
                {

                }
                if (action == "Rate")
                {
                    foreach (var item in plants)
                    {
                        if (item.Name == currentPlant)
                        {
                            item.Rating.Add(double.Parse(splitTheCommand[1]));
                        }
                        
                    }
                }
                else if (action == "Update")
                {
                    foreach (var item in plants)
                    {
                        if (item.Name == currentPlant)
                        {
                            item.Rarity = int.Parse(splitTheCommand[1]);
                        }
                    }
                }
                else if (action == "Reset")
                {
                    foreach (var item in plants)
                    {
                        if (item.Name == currentPlant)
                        {
                            item.Rating.Clear();
                            item.Rating.Add(0);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            foreach (var item in plants)
            {
                if (item.Rating.Count == 0)
                {
                    item.Rating.Add(0);
                }
            }
            Console.WriteLine($"Plants for the exhibition:");
            foreach (var item in plants.OrderByDescending(x => x.Rarity).ThenByDescending(y => y.Rating.Average()))
            {
                Console.WriteLine($"- {item.Name}; Rarity: {item.Rarity}; Rating: {item.Rating.Average():f2}");
            }
        }

        public class Plant
        {
            public string Name { get; set; }
            public double Rarity { get; set; }
            public List<double> Rating { get; set; }

            public Plant(string name)
            {
                this.Name = name;
                //this.Rarity = 0;
                this.Rating = new List<double>();
            }
        }


    }
}
