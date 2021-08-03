using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> citiesPopulation = new Dictionary<string, int>();
            Dictionary<string, int> citiesGold = new Dictionary<string, int>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Sail")
                {
                    break;
                }

                string[] cityInfo = command.Split("||").ToArray();
                string city = cityInfo[0];
                int population = int.Parse(cityInfo[1]);
                int gold = int.Parse(cityInfo[2]);
                if (!citiesPopulation.ContainsKey(city))
                {
                    citiesPopulation.Add(city, population);
                    citiesGold.Add(city, gold);

                }
                else
                {
                    citiesGold[city] += gold;
                    citiesPopulation[city] += population;

                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                string[] cmd = command.Split("=>").ToArray();
                string action = cmd[0];
                string city = cmd[1];
                
                if (cmd[0] == "Plunder")
                {
                    int peopleKilled = int.Parse(cmd[2]);
                    int goldStolled = int.Parse(cmd[3]);
                    Console.WriteLine($"{city} plundered! {goldStolled} gold stolen, {peopleKilled} citizens killed.");
                    if (citiesGold.ContainsKey(city))
                    {
                        citiesGold[city] -= goldStolled;
                        citiesPopulation[city] -= peopleKilled;
                        if (citiesGold[city] <=0 || citiesPopulation[city] <= 0)
                        {
                            Console.WriteLine($"{city} has been wiped off the map!");
                            citiesGold.Remove(city);
                            citiesPopulation.Remove(city);
                        }
                        
                    }
                }
                else if (cmd[0] == "Prosper")
                {
                    int gold = int.Parse(cmd[2]);
                    if (gold <0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        if (citiesGold.ContainsKey(city))
                        {
                            citiesGold[city] += gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {citiesGold[city]} gold.");
                        }
                        
                    }
                }
            }

            if (citiesGold.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                var orderedDictionary = citiesGold.OrderByDescending(x => x.Value).ThenBy(y => y.Key);
                Console.WriteLine($"Ahoy, Captain! There are {orderedDictionary.Count()} wealthy settlements to go to:");
                StringBuilder sb = new StringBuilder();
                foreach (var city in orderedDictionary)
                {
                    string currentCity = city.Key;
                    int currentGold = city.Value;
                    int currentPopulation = citiesPopulation[currentCity];
                    sb.AppendLine($"{currentCity} -> Population: {currentPopulation} citizens, Gold: {currentGold} kg");
                }

                Console.WriteLine(sb.ToString().TrimEnd());
            }
            

        }
    }
}
