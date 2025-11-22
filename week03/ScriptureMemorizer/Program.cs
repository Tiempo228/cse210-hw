using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    private static List<Scripture> _scriptures;
    private static Random _random;

    static void Main(string[] args)
    {
        // EXCEEDING REQUIREMENTS:
        // Load scriptures from JSON file 
        _scriptures = new List<Scripture>();
        _random = new Random();
        LoadScripturesFromJson();
        RunMemorizer();
    }

    private static void LoadScripturesFromJson()
    {
        try
        {
            if (File.Exists("scriptures.json"))
            {
                string jsonText = File.ReadAllText("scriptures.json");
                var scriptureData = JsonSerializer.Deserialize<List<JsonScripture>>(jsonText);

                foreach (var data in scriptureData)
                {
                    Reference reference;
                    if (data.StartVerse == data.EndVerse)
                    {
                        reference = new Reference(data.Book, data.Chapter, data.StartVerse);
                    }
                    else
                    {
                        reference = new Reference(data.Book, data.Chapter, data.StartVerse, data.EndVerse);
                    }

                    _scriptures.Add(new Scripture(reference, data.Text));
                }

                Console.WriteLine($"Loaded {_scriptures.Count} scriptures from JSON file.");
            }
            else
            {
                // Fallback to default scriptures if JSON file doesn't exist
                LoadDefaultScriptures();
                Console.WriteLine("Using default scriptures (scriptures.json not found).");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading scriptures from JSON: {ex.Message}");
            LoadDefaultScriptures();
            Console.WriteLine("Using default scriptures due to error.");
        }
    }

    private static void LoadDefaultScriptures()
    {
        // Default scriptures in case JSON file is missing
        _scriptures.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
        ));

        _scriptures.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."
        ));
    }

    private static void RunMemorizer()
    {
        if (_scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures available to memorize.");
            return;
        }

        // Select a random scripture from the library
        Scripture scripture = _scriptures[_random.Next(_scriptures.Count)];

        Console.Clear();
        Console.WriteLine("Welcome to Scripture Memorizer!");
        Console.WriteLine("===============================\n");

        while (true)
        {
            // Display the scripture
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            // Check if all words are hidden
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden! Great job memorizing!");
                break;
            }

            // Prompt user
            Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            // Hide 2-3 random words and clear console
            scripture.HideRandomWords(_random.Next(2, 4));
            Console.Clear();
        }

        Console.WriteLine("\nThank you for using Scripture Memorizer!");
    }
}

// Helper class for JSON deserialization
public class JsonScripture
{
    public string Book { get; set; }
    public int Chapter { get; set; }
    public int StartVerse { get; set; }
    public int EndVerse { get; set; }
    public string Text { get; set; }
}