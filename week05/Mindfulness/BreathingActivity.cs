using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 0)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        int cycleCount = 0;

        Console.WriteLine();

        while (DateTime.Now < endTime)
        {
            cycleCount++;
            Console.Write($"Breathe in... (Cycle {cycleCount}) ");
            ShowBreathingAnimation("Breathe in... ", 4, true);

            
            TimeSpan remaining = endTime - DateTime.Now;
            if (remaining.TotalSeconds >= 6)
            {
                Console.Write("Now breathe out... ");
                ShowBreathingAnimation("Now breathe out... ", 6, false);
            }
            else if (remaining.TotalSeconds > 0)
            {
                Console.Write("Now breathe out... ");
                ShowCountDown((int)remaining.TotalSeconds);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}