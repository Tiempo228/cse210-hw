using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");

        Fraction frac1 = new Fraction();
        Fraction frac2 = new Fraction(2);
        Fraction frac3 = new Fraction(4, 5);
        // Fraction frac4 = new Fraction(3, 4);

        Console.WriteLine("\n// Constructor with no argument");
        Console.WriteLine(frac1.GetFractionString());
        Console.WriteLine(frac1.GetDecimalValue());

        Console.WriteLine("// Constructor with whole number");
        Console.WriteLine(frac2.GetFractionString());
        Console.WriteLine(frac2.GetDecimalValue());

        Console.WriteLine("// Constructor with arguments");
        Console.WriteLine(frac3.GetFractionString());
        Console.WriteLine(frac3.GetDecimalValue());


        Console.WriteLine("\n// Fraction top set to 3");
        frac1.SetTop(3);
        frac2.SetTop(3);
        frac3.SetTop(3);
        Console.WriteLine(frac1.GetFractionString());
        Console.WriteLine(frac1.GetDecimalValue());

        Console.WriteLine(frac2.GetFractionString());
        Console.WriteLine(frac2.GetDecimalValue());

        Console.WriteLine(frac3.GetFractionString());
        Console.WriteLine(frac3.GetDecimalValue());

        Console.WriteLine("\n// Fraction bottom set to 9");
        frac1.SetBottom(9);
        frac2.SetBottom(9);
        frac3.SetBottom(9);
        Console.WriteLine(frac1.GetFractionString());
        Console.WriteLine(frac1.GetFractionString());

        Console.WriteLine(frac2.GetFractionString());
        Console.WriteLine(frac2.GetDecimalValue());

        Console.WriteLine(frac3.GetFractionString());
        Console.WriteLine(frac3.GetDecimalValue());



    }
}