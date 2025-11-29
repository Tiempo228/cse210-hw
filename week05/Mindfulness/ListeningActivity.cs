using System;
using System.Collections.Generic;
using System.IO;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private List<string> _usedPrompts;
    private List<string> _userItems;

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 0)
    {
        _count = 0;
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
            "What are you grateful for today?",
            "What made you smile recently?",
            "What are you looking forward to?",
            "What accomplishments are you proud of?",
            "Who has positively impacted your life?"
        };
        _usedPrompts = new List<string>();
        _userItems = new List<string>();
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        string prompt = GetRandomPrompt();
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        GetListFromUser();

        Console.WriteLine($"You listed {_count} items!");

        // Save the list to a file if user wants
        SaveListToFile(prompt);

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        // If all prompts have been used, reset the used list
        if (_usedPrompts.Count >= _prompts.Count)
        {
            _usedPrompts.Clear();
        }

        Random random = new Random();
        string selectedPrompt;

        do
        {
            int index = random.Next(_prompts.Count);
            selectedPrompt = _prompts[index];
        } while (_usedPrompts.Contains(selectedPrompt));

        _usedPrompts.Add(selectedPrompt);
        return selectedPrompt;
    }

    public void GetListFromUser()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        _count = 0;
        _userItems.Clear();

        Console.WriteLine("Start listing items (press Enter after each item):");
        Console.WriteLine("(Type 'done' to finish early)\n");

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (input?.ToLower() == "done")
                break;

            if (!string.IsNullOrWhiteSpace(input))
            {
                _count++;
                _userItems.Add(input);

                // Show a quick spinner between entries
                if (DateTime.Now < endTime)
                {
                    Console.Write("Added! ");
                    ShowSpinner(1);
                    Console.WriteLine();
                }
            }

            // Show time remaining every 5 items
            if (_count % 5 == 0 && _count > 0)
            {
                TimeSpan remaining = endTime - DateTime.Now;
                Console.WriteLine($"\nTime remaining: {(int)remaining.TotalSeconds} seconds...\n");
            }
        }
    }

    private void SaveListToFile(string prompt)
    {
        if (_userItems.Count > 0)
        {
            Console.Write("\nWould you like to save your list to a file? (y/n): ");
            string response = Console.ReadLine()?.ToLower();

            if (response == "y" || response == "yes")
            {
                try
                {
                    string filename = $"mindfulness_list_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                    using (StreamWriter writer = new StreamWriter(filename))
                    {
                        writer.WriteLine($"Mindfulness Listing Activity - {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                        writer.WriteLine($"Prompt: {prompt}");
                        writer.WriteLine($"Duration: {_duration} seconds");
                        writer.WriteLine($"Items listed: {_count}");
                        writer.WriteLine("\nYour items:");
                        writer.WriteLine(new string('-', 40));

                        for (int i = 0; i < _userItems.Count; i++)
                        {
                            writer.WriteLine($"{i + 1}. {_userItems[i]}");
                        }
                    }
                    Console.WriteLine($"List saved to {filename}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not save the list to file.");
                }
            }
        }
    }
}