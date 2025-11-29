using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private List<string> _gratitudePrompts;
    private List<string> _gratitudeItems;

    public GratitudeActivity() : base("Gratitude", "This activity will help you cultivate gratitude by focusing on specific things you're thankful for and reflecting on why they matter to you.", 0)
    {
        _gratitudePrompts = new List<string>
        {
            "What relationships are you grateful for and why?",
            "What simple pleasures brought you joy recently?",
            "What challenges have helped you grow?",
            "What opportunities are you thankful for?",
            "What aspects of your health are you grateful for?",
            "What skills or talents are you thankful to have?",
            "What moments of beauty have you experienced lately?",
            "What support systems are you grateful for?"
        };

        _gratitudeItems = new List<string>();
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("This activity has two parts:");
        Console.WriteLine("1. Quick gratitude listing");
        Console.WriteLine("2. Deep reflection on selected items");
        Console.WriteLine();

        //Quick listing
        Console.WriteLine("Part 1: Let's start with quick gratitude items.");
        Console.WriteLine("List things you're grateful for (one per line):");
        Console.WriteLine("You have 30 seconds to list as many as you can!");
        Console.Write("Starting in: ");
        ShowCountDown(3);
        Console.WriteLine();

        QuickGratitudeListing();

        // Deep reflection
        Console.WriteLine("\nPart 2: Now let's reflect more deeply.");
        Console.WriteLine("We'll focus on a few items from your list.");
        DeepGratitudeReflection();

        DisplayEndingMessage();

        // Save gratitude practice
        SaveGratitudePractice();
    }

    private void QuickGratitudeListing()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(30);
        _gratitudeItems.Clear();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                _gratitudeItems.Add(input);
            }
        }

        Console.WriteLine($"\nGreat! You listed {_gratitudeItems.Count} things you're grateful for.");
        ShowSpinner(2);
    }

    private void DeepGratitudeReflection()
    {
        if (_gratitudeItems.Count == 0)
        {
            Console.WriteLine("No items to reflect on. Let's add some now.");
            Console.WriteLine("Please list 3 things you're grateful for:");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i + 1}. ");
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    _gratitudeItems.Add(item);
                }
            }
        }

        Random random = new Random();
        int itemsToReflect = Math.Min(3, _gratitudeItems.Count);

        for (int i = 0; i < itemsToReflect; i++)
        {
            string item = _gratitudeItems[random.Next(_gratitudeItems.Count)];
            Console.WriteLine($"\nReflecting on: {item}");
            Console.WriteLine("Why are you grateful for this?");
            ShowSpinner(5);

            Console.WriteLine("How does this enrich your life?");
            ShowSpinner(5);

            Console.WriteLine("Take a moment to fully appreciate this...");
            ShowSpinner(3);
        }
    }

    private void SaveGratitudePractice()
    {
        try
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Gratitude practice with {_gratitudeItems.Count} items\n";
            File.AppendAllText("mindfulness_log.txt", logEntry);
        }
        catch (Exception)
        {
            // Silently handle file errors
        }
    }

}