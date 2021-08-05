using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> heroHP = new Dictionary<string, int>();
            Dictionary<string, int> heroMP = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] heroData = Console.ReadLine().Split().ToArray();
                string hero = heroData[0];
                int heroH = int.Parse(heroData[1]);
                int heroM = int.Parse(heroData[2]);
                if (!heroHP.ContainsKey(hero))
                {
                    heroHP.Add(hero, heroH);
                    heroMP.Add(hero, heroM);
                }
                
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                string[] cmd = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = cmd[0];
                if (action == "CastSpell")
                {
                    string heroName = cmd[1];
                    int MPneeded = int.Parse(cmd[2]);
                    string spellName = cmd[3];
                    if (heroMP[heroName] >= MPneeded)
                    {
                        heroMP[heroName] -= MPneeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroMP[heroName]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (action == "TakeDamage")
                {
                    string heroName = cmd[1];
                    int damage = int.Parse(cmd[2]);
                    string attacker = cmd[3];
                    int HPLeft = heroHP[heroName] - damage;
                    if (HPLeft > 0)
                    {
                        heroHP[heroName] -= damage;
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroHP[heroName]} HP left!");
                    }
                    else
                    {
                        heroHP.Remove(heroName);
                        heroMP.Remove(heroName);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }
                else if (action == "Recharge")
                {
                    string heroName = cmd[1];
                    int amount = int.Parse(cmd[2]);
                    if (heroMP[heroName] + amount > 200)
                    {
                        int amountRecharged = 200 - heroMP[heroName];
                        heroMP[heroName] = 200;
                        Console.WriteLine($"{heroName} recharged for {amountRecharged} MP!");

                    }
                    else
                    {
                        heroMP[heroName] += amount;
                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
                    }
                   
                }
                else if (action == "Heal")
                {
                    string heroName = cmd[1];
                    int amount = int.Parse(cmd[2]);
                    if (heroHP[heroName] + amount > 100)
                    {
                        int amountRecharged = 100 - heroHP[heroName];
                        heroHP[heroName] = 100;
                        Console.WriteLine($"{heroName} healed for {amountRecharged} HP!");

                    }
                    else
                    {
                        heroHP[heroName] += amount;
                        Console.WriteLine($"{heroName} healed for {amount} HP!");
                    }
                }
            }

            foreach (var item in heroHP.OrderByDescending(x=> x.Value).ThenBy(y=> y.Key))
            {
                Console.WriteLine($"{item.Key}");
                Console.WriteLine($"  HP: {item.Value}");
                Console.WriteLine($"  MP: {heroMP[item.Key]}");
            }
        }
    }
}
