using System;
using System.Linq;
using System.Text;

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Travel")
                {
                    break;
                }
                string[] stop = command.Split(":").ToArray();
                if (stop[0] == "Add Stop")
                {

                    int index = int.Parse(stop[1]);
                    if (0 <= index && index < stops.Length)
                    {
                        stops = stops.Insert(index, stop[2]);
                    }
                   
                }
                else if (stop[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(stop[1]);
                    int endIndex = int.Parse(stop[2]);
                    if ((0 <= startIndex && startIndex < stops.Length) && (0 <= endIndex && endIndex < stops.Length))
                    {
                        if ((endIndex >= startIndex))
                        {
                            stops = stops.Remove(startIndex, endIndex - startIndex + 1);
                        }

                    }

                }
                else if (stop[0] == "Switch")
                {
                    if (stop[1] != stop[2])
                    {
                        if (stops.Contains(stop[1]))
                        {
                            stops = stops.Replace(stop[1], stop[2]);
                        }
                    }
                                  


                }
                Console.WriteLine(stops);
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
