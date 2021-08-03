using System;
using System.Linq;

namespace FundFinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Generate")
                {
                    break;
                }

                string[] cmd = command.Split(">>>").ToArray();
                if (cmd[0] == "Contains")
                {
                    string substring = cmd[1];
                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (cmd[0] == "Flip")
                {
                    string substringToFlip = activationKey.Substring(int.Parse(cmd[2]), int.Parse(cmd[3]) - int.Parse(cmd[2]));
                    string flipped = string.Empty;
                    if (cmd[1] == "Lower")
                    {
                        flipped = substringToFlip.ToLower();

                    }
                    else
                    {
                        flipped = substringToFlip.ToUpper();
                    }

                    activationKey = activationKey.Replace(substringToFlip, flipped);
                    Console.WriteLine(activationKey);
                }
                else if (cmd[0] == "Slice")
                {
                    int firstIndex = int.Parse(cmd[1]);
                    int LastIndex = int.Parse(cmd[2]);
                    int lenght = LastIndex - firstIndex;
                    activationKey = activationKey.Remove(firstIndex, lenght);
                    Console.WriteLine(activationKey);
                }
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
