using System;
using System.Linq;

namespace HearthDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine().Split("@").Select(int.Parse).ToArray();
            int cupidLocation = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Love!")
                {
                    break;
                }
                string[] cmd = command.Split().ToArray();
                int jump = int.Parse(cmd[1]);
                if (cupidLocation + jump >= neighborhood.Length)
                {
                    cupidLocation = 0;
                    if (neighborhood[cupidLocation] == 0)
                    {
                        Console.WriteLine($"Place {cupidLocation} already had Valentine's day.");
                        continue;
                    }

                    neighborhood[cupidLocation] -= 2;
                    if (neighborhood[cupidLocation] == 0)
                    {
                        Console.WriteLine($"Place {cupidLocation} has Valentine's day.");
                        continue;
                    }
                    continue;
                }
                cupidLocation += jump;
                if (neighborhood[cupidLocation] == 0)
                {
                    Console.WriteLine($"Place {cupidLocation} already had Valentine's day.");
                    continue;
                }
                
                neighborhood[cupidLocation] -= 2;
                if (neighborhood[cupidLocation] == 0)
                {
                    Console.WriteLine($"Place {cupidLocation} has Valentine's day.");
                }

            }

            Console.WriteLine($"Cupid's last position was {cupidLocation}.");
            if (neighborhood.Sum()==0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                int failed = neighborhood.Count(x => x != 0);
                Console.WriteLine($"Cupid has failed {failed} places.");        
            }
            
        }
    }
}
