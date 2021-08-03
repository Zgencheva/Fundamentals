using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> coolEmoji = new List<string>(); 
            //List<string> notValidEmoji = new List<string>();
            long threshold = 1;

            string patternNum = @"\d";
            MatchCollection matches = Regex.Matches(input, patternNum);
            foreach (Match match in matches)
            {
                int theid = int.Parse(match.Value);
                threshold *= theid;
            }

            Console.WriteLine($"Cool threshold: {threshold}");

            string patternWords = @"([:]{2}|[*]{2})(?<name>[A-Z][a-z]{2,})\1";
          

            MatchCollection matches1 = Regex.Matches(input, patternWords);
            

            Console.Write($"{matches1.Count} emojis found in the text. ");
            

            foreach (Match item in matches1)
            {
                string line = item.Value;
                char[] lineToChars = line.ToCharArray();
                int sumChars = 0;
                foreach (char ch in lineToChars)
                {
                    if (ch != 42 && ch!= 58)
                    {
                        sumChars += ch;
                    }
                }
                if (sumChars >= threshold)
                {
                    coolEmoji.Add(line);
                }
                    
            }

          

            Console.WriteLine("The cool ones are:");
            Console.WriteLine(string.Join("\n", coolEmoji));
        }
    }
}
