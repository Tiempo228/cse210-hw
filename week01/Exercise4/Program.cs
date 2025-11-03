using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        List<int> numberList = new List<int>();
        bool num = true;

        while (num)
        {
            Console.Write("Enter a list of numbers both posivitive and negative: ");
            int value = int.Parse(Console.ReadLine());
            if (value != 0)
            {
                numberList.Add(value);
            }
            else
            {
                num = false;
            }
        }

        int sum = numberList.Sum();
        double avrg = numberList.Average();
        int max = numberList.Max();
        int smallPos = numberList.Where(n => n > 0).Min();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avrg}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {smallPos}");
        Console.WriteLine("The sorted list is:");

        foreach (int val in numberList.OrderBy(p => p))
        {
            Console.WriteLine($"{val}");

        }





    }
}