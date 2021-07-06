using System;
using System.Collections.Generic;

namespace ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            double countOfStudents = double.Parse(Console.ReadLine());
            double countOfLectures = double.Parse(Console.ReadLine());
            double bonus = double.Parse(Console.ReadLine());
            Dictionary<double, double> points = new Dictionary<double, double>();
            double bestBonus = 0;
            double bestAttendance = 0;
            if (countOfLectures == 0 || countOfStudents == 0)
            {
                Console.WriteLine($"Max Bonus: 0.");
                Console.WriteLine($"The student has attended 0 lectures.");
                return;

            }
            
            for (int i = 0; i < countOfStudents; i++)
            {
                double studentAttendance = double.Parse(Console.ReadLine());
               
                double totalBonus = (studentAttendance / countOfLectures) * (5 + bonus);
                if (!points.ContainsKey(totalBonus))
                {
                    points.Add(totalBonus, studentAttendance);
                }
                
            }

            foreach (var point in points)
            {
                if (point.Key > bestBonus)
                {
                    bestBonus = point.Key;
                    bestAttendance = point.Value;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(bestBonus)}.");
            Console.WriteLine($"The student has attended {bestAttendance} lectures.");
        }
    }
}
