using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
        Random random = new Random();

        bool continueAnswer = true;

        while (continueAnswer)
        {
            int magicNumber = random.Next(1, 101);
            int guessNumber = 0;
            int attempts = 0;

            Console.WriteLine("Welcome to the Guess My Number game!");
            Console.WriteLine("Guess a number between 1 and 100:");

            while (magicNumber != guessNumber)
            {
                Console.Write("Enter a guess number: ");
                guessNumber = int.Parse(Console.ReadLine());
                attempts += 1;

                if (magicNumber > guessNumber)
                {
                    Console.WriteLine("Lower!");

                }
                else if (magicNumber < guessNumber)
                {
                    Console.WriteLine("Higher!");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.WriteLine($"You've made {attempts} attempts");

            Console.Write("Do you wish try it again? (yes/no) ");
            string response = Console.ReadLine().ToLower();

            if (response == "no")
            {
                continueAnswer = false;
                Console.WriteLine("Thank you for playing the game!");

            }


        }
    }
}