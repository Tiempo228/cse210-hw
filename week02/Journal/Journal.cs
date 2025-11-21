using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;
    private PromptGenerator _promptGenerator;

    public Journal()
    {
        _entries = new List<Entry>();
        _promptGenerator = new PromptGenerator();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.\n");
            return;
        }

        Console.WriteLine("\n=== JOURNAL ENTRIES ===\n");
        foreach (Entry entry in _entries)
        {
            entry.displayEntryData();
        }
    }

    public void SaveToFile(string file)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine(entry.SaveFormat());
                }
            }
            Console.WriteLine($"Journal saved to {file} successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}\n");
        }
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File does not exist.\n");
            return;
        }

        try
        {
            List<Entry> loadedEntries = new List<Entry>();
            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry(parts[1], parts[2], parts[0]);
                    loadedEntries.Add(entry);
                }
            }

            _entries = loadedEntries;
            Console.WriteLine($"Journal loaded from {file} successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}\n");
        }
    }

    public void WriteNewEntry()
    {
        string randomPrompt = _promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {randomPrompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        string currentDate = DateTime.Now.ToString("MM/dd/yyyy");

        Entry newEntry = new Entry(randomPrompt, response, currentDate);
        AddEntry(newEntry);

        Console.WriteLine("Entry saved successfully!\n");
    }

    public bool HasEntries()
    {
        return _entries.Count > 0;
    }
}