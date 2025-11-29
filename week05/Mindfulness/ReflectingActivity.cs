using System;
using System.Collections.Generic;
using System.IO;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _usedPrompts;
    private List<string> _usedQuestions;

    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 0)
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you overcame a significant challenge.",
            "Think of a moment when you felt particularly proud of yourself.",
            "Think of a time when you learned an important life lesson."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
            "Who was involved in this experience and how did they impact it?",
            "What would you do differently if you faced this situation again?",
            "How did this experience change your perspective?"
        };

        _usedPrompts = new List<string>();
        _usedQuestions = new List<string>();
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        DisplayPrompt();
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DisplayQuestions();

        DisplayEndingMessage();

        // Save reflection to log file
        SaveReflectionToLog();
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

    public string GetRandomQuestion()
    {
        // If all questions have been used, reset the used list
        if (_usedQuestions.Count >= _questions.Count)
        {
            _usedQuestions.Clear();
        }

        Random random = new Random();
        string selectedQuestion;

        do
        {
            int index = random.Next(_questions.Count);
            selectedQuestion = _questions[index];
        } while (_usedQuestions.Contains(selectedQuestion));

        _usedQuestions.Add(selectedQuestion);
        return selectedQuestion;
    }

    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"--- {prompt} ---");
    }

    public void DisplayQuestions()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime && _usedQuestions.Count < _questions.Count)
        {
            string question = GetRandomQuestion();
            Console.Write($"> {question} ");
            ShowSpinner(8);
            Console.WriteLine();
        }
    }

    private void SaveReflectionToLog()
    {
        try
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Completed {_duration} seconds of Reflection Activity\n";
            File.AppendAllText("mindfulness_log.txt", logEntry);
        }
        catch (Exception ex)
        {
            //handle file errors 
            Console.WriteLine("Note: Could not save to activity log.");
        }
    }
}