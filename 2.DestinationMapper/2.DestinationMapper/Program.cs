using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace _2.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(?<symbol>[=\/])(?<destination>[A-Z]{1}[A-Za-z]{2,})\k<symbol>";
            string input = Console.ReadLine();
            List<string> dest = new List<string>();
            MatchCollection destinations = Regex.Matches(input, regex);
            foreach (Match match in destinations)
            {
                dest.Add(match.Groups["destination"].ToString());
            }
            Console.Write("Destinations: ");
            
            Console.Write(string.Join(", ", dest));
            int points = 0;
            foreach (var item in dest)
            {
                points += item.Length;
            }
            Console.WriteLine($"\nTravel Points: {points}");
            
        }
    }
}
