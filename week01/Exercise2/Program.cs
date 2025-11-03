using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade percentage, please: ");
        int gradePerc = int.Parse(Console.ReadLine());
        string letter = "";
        int lastDigit = gradePerc % 10;

        if (gradePerc >= 90)
        {
            letter = "A";
        }
        else if (80 <= gradePerc && gradePerc < 90)
        {
            letter = "B"; ;
        }
        else if (70 <= gradePerc && gradePerc < 80)
        {
            letter = "C";
        }
        else if (60 <= gradePerc && gradePerc < 70)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your Letter grade is {letter}");

        if (70 <= gradePerc && gradePerc >= 90)
        {
            Console.WriteLine("Congratulation! you passed the course.");
        }
        else
        {
            Console.WriteLine("S0rry, you failed. Don't give up! Better luck next time!");

        }

    }
}
