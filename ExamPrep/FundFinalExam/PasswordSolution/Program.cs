using System;
using System.Linq;
using System.Text;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            
            //string result = string.Empty;
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "Done")
                {
                    break;
                }
               
                string[] command = cmd.Split().ToArray();
                if (command[0] == "TakeOdd")
                {
                    char[] codeToChar = password.ToCharArray();
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < codeToChar.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            sb.Append(codeToChar[i]);
                        }
                    }
                    password = sb.ToString();
                    Console.WriteLine(password);
                   
                }
                else if (command[0] == "Cut")
                {

                    password = password.Remove(int.Parse(command[1]), int.Parse(command[2]));
                    Console.WriteLine(password);
                }
                else if (command[0] == "Substitute")
                {
                    string substring = command[1];
                    string substitute = command[2];
                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
