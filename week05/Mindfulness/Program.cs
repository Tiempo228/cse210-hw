using System;
using System.IO;
using System.Threading;

class Program
{
    /*
    Exceeding Requirements:
    
    1. Added a FOURTH activity: Gratitude Activity
       - Combines quick listing with deep reflection
       - Helps users cultivate gratitude specifically
    
    2. Enhanced animation system:
       - Added growing/shrinking animation for breathing activity
       - More engaging visual feedback
    
    3. Activity statistics tracking:
       - Tracks total activities completed
       - Tracks counts for each activity type
       - Displays statistics to user
    
    4. Smart prompt/question selection:
       - Ensures no repeats until all have been used
       - Prevents duplicate prompts in same session
    
    5. File logging system:
       - Saves activity completion to log file
       - Allows saving lists to files for reflection activity
       - Preserves user's work
    
    6. Enhanced user experience:
       - Input validation for duration
       - Time remaining indicators
       - Early completion options
       - Progress indicators
    
    7. Additional prompts and questions:
       - Expanded lists for more variety
       - More thoughtful reflection questions
    */

    static void Main(string[] args)
    {
        Console.WriteLine("Initializing Mindfulness Program...");
        ShowStartupAnimation();

        while (true)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case "2":
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                case "4":
                    GratitudeActivity gratitudeActivity = new GratitudeActivity();
                    gratitudeActivity.Run();
                    break;
                case "5":
                    Activity.DisplayActivityStats();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "6":
                    DisplayAboutInfo();
                    break;
                case "7":
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    ShowClosingAnimation();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select 1-7.");
                    ShowSpinner(2);
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("🌿 Mindfulness Program 🌿");
        Console.WriteLine("==========================");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Gratitude Activity  🌟 NEW!");
        Console.WriteLine("5. View Statistics");
        Console.WriteLine("6. About This Program");
        Console.WriteLine("7. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    static void DisplayAboutInfo()
    {
        Console.Clear();
        Console.WriteLine("About the Mindfulness Program");
        Console.WriteLine("=============================");
        Console.WriteLine("This program is designed to help you practice mindfulness");
        Console.WriteLine("through various guided activities.");
        Console.WriteLine();
        Console.WriteLine("Features:");
        Console.WriteLine("- Breathing exercises for relaxation");
        Console.WriteLine("- Reflection prompts for deeper thinking");
        Console.WriteLine("- Listing activities for broad perspective");
        Console.WriteLine("- Gratitude practice for positive focus");
        Console.WriteLine("- Activity tracking and statistics");
        Console.WriteLine();
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey();
    }

    static void ShowStartupAnimation()
    {
        Console.Clear();
        string[] frames = { "🌿 ", "🌱 ", "🍃 ", "🌾 " };

        for (int i = 0; i < 8; i++)
        {
            Console.Write($"\rStarting Mindfulness Program {frames[i % 4]}");
            Thread.Sleep(200);
        }
        Console.WriteLine("\rStarting Mindfulness Program... Done! ");
        Thread.Sleep(1000);
    }

    static void ShowClosingAnimation()
    {
        string[] frames = { "✨", "🌟", "💫", "⭐" };

        for (int i = 0; i < 6; i++)
        {
            Console.Write($"\rThank you for being mindful! {frames[i % 4]} ");
            Thread.Sleep(300);
        }
        Console.WriteLine();
    }

    static void ShowSpinner(int seconds)
    {
        string[] animation = { "|", "/", "-", "\\" };
        int animationIndex = 0;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(animation[animationIndex]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            animationIndex = (animationIndex + 1) % animation.Length;
        }
    }
}