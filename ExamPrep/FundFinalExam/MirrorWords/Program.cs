using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string regexPattern = @"(\@|\#{1})(([A-Z]|[a-z]){3,})\1\1(([A-Z]|[a-z]){3,})\1";
            MatchCollection matches = Regex.Matches(input, regexPattern);
            int wordPairsFound = matches.Count;
            if (wordPairsFound == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            List<string> wordPairs = new List<string>();

            foreach (Match match in matches)
            {
                char[] currentWord = match.Value.ToCharArray();
                string word1 = string.Empty;
                string word2 = string.Empty;
                int startIndexOfWord2 = 0;
                for (int i = 1; i < currentWord.Length; i++)
                {
                    if (currentWord[i] == '#' || currentWord[i] == '@')
                    {
                        startIndexOfWord2 = i + 2;
                        break;
                    }
                    word1 += currentWord[i];

                }
                for (int i = startIndexOfWord2; i < currentWord.Length - 1; i++)
                {
                    if (currentWord[i] == '#' || currentWord[i] == '@')
                    {

                        break;
                    }
                    word2 += currentWord[i];

                }

                if (word1.Length != word2.Length)
                {
                    continue;
                }
                string reversedWord2 = string.Empty;
                for (int i = word2.Length - 1; i >= 0; i--)
                {
                    reversedWord2 += word2[i];
                }
                if (reversedWord2 == word1)
                {

                    wordPairs.Add($"{word1} <=> {word2}");
                }
            }
            if (wordPairs.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", wordPairs));
            }

        }
    }
}
