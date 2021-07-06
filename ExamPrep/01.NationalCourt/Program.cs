using System;
using System.Linq;

namespace _01.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int employees = 3;
            double allEmployeeEfficientlyPerHour = 0;
            int timeNeeededToAnswerAllPeople = 0;

            for (int i = 0; i < employees; i++)
            {
                double eachEmployeeEfficientlyPerHour = double.Parse(Console.ReadLine());
                allEmployeeEfficientlyPerHour += eachEmployeeEfficientlyPerHour;
            }
            double peopleCount = double.Parse(Console.ReadLine());

            while (peopleCount > 0)
            {
                timeNeeededToAnswerAllPeople++;
                if (timeNeeededToAnswerAllPeople % 4 == 0)
                {
                    continue;
                }
                peopleCount -= allEmployeeEfficientlyPerHour;
            }
            Console.WriteLine($"Time needed: {timeNeeededToAnswerAllPeople}h.");

        }
    }
}
