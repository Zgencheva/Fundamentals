using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            string withoutWS = RemoveWhitespace(input1);
            string[] input = withoutWS.Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (!IsTicketValid(input[i]))
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                string regexPattern = @"([\@\#\$\^]{6,10})(.*)\1";
                string item = input[i];
                var match = Regex.Match(item, regexPattern);
                if (match.Success)
                {
                   
                    var winnings = match.Groups;
                    var winningGroup = winnings[1].ToString();
                    char winningChar = winningGroup[0];
                    if (winningGroup.Length == 20)
                    {
                        Console.WriteLine($"ticket \"{input[i]}\" - 10{winningChar} Jackpot!");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{input[i]}\" - {winningGroup.Length}{winningChar}");
                    }
                    

                }
                else
                {
                    Console.WriteLine($"ticket \"{input[i] }\" - no match");
                }
            }
            static bool IsTicketValid(string inputWord)
            {
                if (inputWord.Length == 20)
                {
                    return true;
                }

                return false;

            }
            static string RemoveWhitespace(string input)
            {
                return new string(input.ToCharArray()
                    .Where(c => !Char.IsWhiteSpace(c))
                    .ToArray());
            }
        }

        

    }
}
