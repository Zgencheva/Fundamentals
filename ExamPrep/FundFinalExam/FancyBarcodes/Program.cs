using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string validation = @"(\@{1}\#{1,})(?<code>[A-Z][A-Za-z\d]{4,}[A-Z])(\@{1}\#{1,})";
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();  
                Regex regex = new Regex(validation);
                if (regex.IsMatch(input))
                {
                    Match matches = regex.Match(input);
                    string code = matches.Groups["code"].Value;
                    bool containsDigit = code.Any(char.IsDigit);
                    if (containsDigit)
                    {
                        StringBuilder sb = new StringBuilder();
                        char[] codeToChar = code.ToCharArray();
                        for (int c = 0; c < codeToChar.Length; c++)
                        {
                            char currentChar = codeToChar[c];
                            if (Char.IsDigit(currentChar))
                            {
                                sb.Append(currentChar);
                            }
                        }
                        Console.WriteLine($"Product group: {sb.ToString()}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
