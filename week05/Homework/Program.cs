using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Homework Project.");

        MathAssignment matAassignment = new MathAssignment("Beau Benneth", "Multiplication", "3.7", "14 x 9");
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The cause of world war II");

        Console.WriteLine(matAassignment.GetSummary());
        Console.WriteLine(matAassignment.GetHomeWorkList());

        Console.WriteLine();

        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());

    }
}