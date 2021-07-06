using System;
using System.Linq;

namespace MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;
            string[] dungeonsRooms = Console.ReadLine().Split("|");

            for (int i = 0; i < dungeonsRooms.Length; i++)
            {
                string[] currentRoom = dungeonsRooms[i].Split().ToArray();
                string command = currentRoom[0];
                int number = int.Parse(currentRoom[1]);
                if (command == "potion")
                {
                    
                    if (number + health >= 100)
                    {

                        int amountHealed = 100 - health;
                        
                        Console.WriteLine($"You healed for {amountHealed} hp.");
                        health = 100;
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else
                    {
                        health += number;
                        Console.WriteLine($"You healed for {currentRoom[1]} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    
                }
                else if (command == "chest")
                {
                    bitcoins += number;
                    Console.WriteLine($"You found {currentRoom[1]} bitcoins.");
                }
                else
                {
                    //fight monster
                    if (health > number)
                    {
                        health -= number;
                        Console.WriteLine($"You slayed {command}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }

                }
                
            }

            Console.WriteLine($"You've made it!\nBitcoins: {bitcoins}\nHealth: {health}");

        }
    }
}
