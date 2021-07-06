using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            while (true)
            {
                string[] command = Console.ReadLine().Split("- ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = command[0].Trim();
                
                if (action == "Craft!")
                {
                    break;
                }

                string item = command[1];
                if (action == "Collect")
                {
                    if (journal.Any(x=> x== item))
                    {
                        continue;
                    }
                    journal.Add(item);

                }
                if (action == "Drop")
                {
                    string itemExist = journal.Where(x=> x == item).FirstOrDefault();
                    if (itemExist != null)
                    {
                        journal.Remove(item);
                    }
                }
                if (action == "Combine Items")
                {
                    string[] itemToArray = item.Split(":").ToArray();
                    string itemToFind = itemToArray[0];
                    string itemToAddAfter = itemToArray[1];
                    string itemExist = journal.Where(x => x == itemToFind).FirstOrDefault();
                    int indexOfItem = 0;
                    if (itemExist != null)
                    {
                        for (int i = 0; i < journal.Count; i++)
                        {
                            if (journal[i] == itemExist)
                            {
                                indexOfItem = i;
                            }
                        }
                        List<string> listRight = new List<string>();
                        for (int i = 0; i < indexOfItem; i++)
                        {
                            listRight.Add(journal[i]);
                        }
                        listRight.Add(itemExist);
                        listRight.Add(itemToAddAfter);
                        for (int i = indexOfItem + 1; i < journal.Count; i++)
                        {
                            listRight.Add(journal[i]);
                        }
                        journal = listRight;
                    }
                }
                if (action == "Renew")
                {
                    string itemExist = journal.Where(x => x == item).FirstOrDefault();
                    if (itemExist != null)
                    {
                        journal.Remove(item);
                        journal.Add(item);
                    }
                }
                

            }

            Console.WriteLine(string.Join(", ",journal));
        }
    }
}
