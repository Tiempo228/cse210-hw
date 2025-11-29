using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected static int _totalActivitiesCompleted = 0;
    protected static Dictionary<string, int> _activityCounts = new Dictionary<string, int>();

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;

        // Initialize activity counts if not already done
        if (!_activityCounts.ContainsKey("Breathing")) _activityCounts["Breathing"] = 0;
        if (!_activityCounts.ContainsKey("Reflecting")) _activityCounts["Reflecting"] = 0;
        if (!_activityCounts.ContainsKey("Listing")) _activityCounts["Listing"] = 0;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");

        // Input validation for duration
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int duration) && duration > 0)
            {
                _duration = duration;
                break;
            }
            else
            {
                Console.Write("Please enter a positive number: ");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(3);

        // Track activity completion
        _totalActivitiesCompleted++;
        _activityCounts[_name]++;
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
        int animationIndex = 0;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[animationIndex];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");
            animationIndex = (animationIndex + 1) % animationStrings.Count;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void ShowBreathingAnimation(string message, int seconds, bool breatheIn)
    {
        Console.Write(message);

        if (breatheIn)
        {
            // Growing animation for breathing in
            for (int i = 1; i <= seconds; i++)
            {
                Console.Write(new string('=', i));
                Thread.Sleep(1000);
                Console.Write("\r" + new string(' ', message.Length + seconds) + "\r");
                Console.Write(message);
            }
        }
        else
        {
            // Shrinking animation for breathing out
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(new string('=', i));
                Thread.Sleep(1000);
                Console.Write("\r" + new string(' ', message.Length + seconds) + "\r");
                Console.Write(message);
            }
        }
        Console.WriteLine();
    }

    // Static method to display activity statistics
    public static void DisplayActivityStats()
    {
        Console.WriteLine("\n=== Mindfulness Activity Statistics ===");
        Console.WriteLine($"Total activities completed: {_totalActivitiesCompleted}");
        foreach (var activity in _activityCounts)
        {
            Console.WriteLine($"{activity.Key} activities: {activity.Value}");
        }
        Console.WriteLine("=====================================\n");
    }
}