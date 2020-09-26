using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _2.AddAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string regex = @"(?<symbol>[#\|])(?<product>[A-Za-z\s]+)\k<symbol>(?<date>\d{2}\/\d{2}\/\d{2})\k<symbol>(?<calories>\d{1,5})\k<symbol>";
            MatchCollection matches = Regex.Matches(text, regex);
            int totalCalories = 0;
            foreach (Match match in matches)
            {

                totalCalories += int.Parse(match.Groups["calories"].ToString());
            }

            Console.WriteLine($"You have food to last you for: {totalCalories / 2000} days!");

            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups["product"]}, Best before: {match.Groups["date"]}, Nutrition: {match.Groups["calories"]}");
            }
        }


    }
}
