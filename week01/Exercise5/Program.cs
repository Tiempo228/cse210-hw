using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");



        new Program().DisplayResult();

    }

    //DisplayWelcome - Displays the message, "Welcome to the Program!"
    public void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // PromptUserName - Asks for and returns the user's name (as a string)
    public string PromptUserName()
    {
        Console.Write("Enter your user's name: ");
        string name = Console.ReadLine();
        return name;
    }

    // PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
    public int PromptUserNumber()
    {
        Console.Write("Enter your favorite number: ");
        int num = int.Parse(Console.ReadLine());
        return num;
    }

    // SquareNumber - Accepts an integer as a parameter and returns that number squared(as an integer)
    public int SquareNumber(int number)
    {
        int carre = (int)Math.Pow(number, 2);
        return carre;
    }

    // DisplayResult - Accepts the user's name and the squared number and displays them.
    public void DisplayResult()
    {
        string name = PromptUserName();
        int numbreCarre = SquareNumber(PromptUserNumber());
        Console.WriteLine($"Brother {name}, the square of your number is {numbreCarre}");

    }


}