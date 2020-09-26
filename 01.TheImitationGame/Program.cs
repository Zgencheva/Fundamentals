using System;
using System.Linq;
using System.Text;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] output = input.ToCharArray();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Decode")
                {
                    break;
                }
                string[] message = command.Split("|").ToArray();
                string operation = message[0];
                if (operation == "Move")
                {
                    int num = int.Parse(message[1]);
                    for (int i = 0; i < num; i++)
                    {
                        char current = output[0];
                        for (int j = 0; j < output.Length - 1; j++)
                        {
                            output[j] = output[j + 1];
                        }
                        output[output.Length - 1] = current;
                        
                    }
                }
                else if (operation == "Insert")
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < output.Length; i++)
                    {
                        sb.Append(output[i]);
                    }
                    int index = int.Parse(message[1]);
                    string word = message[2];
                    if (0<= index && index <= sb.Length)
                    {

                        if (index == sb.Length)
                        {
                            sb.Append(word);
                        }
                        else
                        {
                            sb.Insert(index, word);
                        }
                        
                        output = sb.ToString().ToCharArray();
                    }
                    
                }
                else if (operation == "ChangeAll")
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < output.Length; i++)
                    {
                        sb.Append(output[i]);
                    }
                    sb.Replace(message[1], message[2]);
                    output = sb.ToString().ToCharArray();
                }
            }
            
            Console.WriteLine($"The decrypted message is: {string.Join("", output)}");
        }
    }
}
