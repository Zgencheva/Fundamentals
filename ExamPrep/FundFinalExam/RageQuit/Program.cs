using System;
using System.Text;
using System.Text.RegularExpressions;

namespace RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([\D]{1,})(\d{1,})";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, pattern);
            StringBuilder sb = new StringBuilder();
            foreach (Match match in matches)
            {
                string word = match.Groups[1].Value.ToString();
                int timesToRepeat = int.Parse(match.Groups[2].Value.ToString());
                
                for (int i = 0; i < timesToRepeat; i++)
                {
                    sb.Append(word.ToUpper());
                }
            }

            string newWord = sb.ToString();
            string uniquePattern = @"(?:(.)(?!.*\1))";
            MatchCollection uniquwMatches = Regex.Matches(newWord, uniquePattern);
            int num = uniquwMatches.Count;

            Console.WriteLine($"Unique symbols used: {num}");
            Console.WriteLine(newWord);



        }
    }
}
