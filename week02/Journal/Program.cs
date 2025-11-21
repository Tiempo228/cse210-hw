using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        Console.WriteLine("=== PERSONAL JOURNAL PROGRAM ===\n");

        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    HandleSaveJournal(journal);
                    break;
                case "4":
                    HandleLoadJournal(journal);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Thank you for journaling! Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Please choose an option:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice (1-5): ");
    }

    static void HandleSaveJournal(Journal journal)
    {
        if (!journal.HasEntries())
        {
            Console.WriteLine("No entries to save. Please write some entries first.\n");
            return;
        }

        Console.Write("Enter filename to save journal: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
    }

    static void HandleLoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load journal: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
    }
}
