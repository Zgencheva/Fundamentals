using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine().Split("!").ToList();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Go Shopping!")
                {
                    break;
                }

                string[] cmd = command.Split().ToArray();
                string status = cmd[0];
                string grocery = cmd[1];
                
                if (status == "Urgent")
                {
                    if (shoppingList.Any(x=> x == grocery))
                    {
                        continue;
                    }
                    List<string> shoppingL2 = new List<string>();
                    shoppingL2.Add(grocery);
                    for (int i = 0; i < shoppingList.Count; i++)
                    {
                        shoppingL2.Add(shoppingList[i]);
                    }
                    shoppingList = shoppingL2;
                }
                else if (status == "Unnecessary")
                {
                    shoppingList.Remove(grocery);
                }
                else if (status == "Correct")
                {
                    if (shoppingList.Any(x => x == grocery))
                    {
                        string newItem = cmd[2];
                        int index = shoppingList.IndexOf(grocery);
                        shoppingList[index] = newItem;
                    }
                    
                }
                else if (status == "Rearrange")
                {
                    if (shoppingList.Any(x=> x == grocery))
                    {
                        shoppingList.Remove(grocery);
                        shoppingList.Add(grocery);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", shoppingList));
        }
    }
}
