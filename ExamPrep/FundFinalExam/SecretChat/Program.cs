using System;
using System.Linq;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Reveal")
                {
                    break;
                }
                string[] cmd = command.Split(":|:").ToArray();
                string action = cmd[0];
                if (action == "InsertSpace")
                {
                    int index = int.Parse(cmd[1]);
                    message = message.Insert(index, " ");
                    Console.WriteLine(message);
                }
                else if (action == "Reverse")
                {
                    string substring = cmd[1];
                    if (message.Contains(substring))
                    {
                        int index = message.IndexOf(substring);
                        message = message.Remove(index, substring.Count());
                        char[] cArray = substring.ToCharArray();
                        string reverse = String.Empty;
                        for (int i = cArray.Length - 1; i > -1; i--)
                        {
                            reverse += cArray[i];
                        }
                        message = message + reverse;
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (action == "ChangeAll")
                {
                    string substring = cmd[1];
                    string replacement = cmd[2];
                    if (message.Contains(substring))
                    {
                        message = message.Replace(substring, replacement);
                    }
                    Console.WriteLine(message);
                    
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
