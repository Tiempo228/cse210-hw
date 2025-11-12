public class Journal
{
    public List<Entry> _entries;
    public List<string> _questions;

    public Journal()
    {
        _entries = new List<Entry>();

        //create a list and populate it with initial elements in a single statement using collection initializer syntax. 
        _questions = new List<string>(){
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What made me laugh today?",
            "What am I grateful for today?",
            "What did I learn today?",
            "How did I help someone today?",
            "What challenge did I overcome today?"
            };

    }

    public void CreateNewEntry()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        string question = _questions[index];
        string response = Console.ReadLine();

        Console.Write($"Question: {question}");
        Console.Write($"Response: {response}");

        // return date in a string format
        string date = DateTime.Now.ToString("mm/dd/yyyy");

        Entry newEntry = new Entry(question, response, date);

        // add entry in entries list
        _entries.Add(newEntry);

    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There is no entry in the journal");
        }
        else
        {
            Console.WriteLine("******** JOURNAL ENTRY *********");
            for (int i = 0; i < _entries.Count; i++)
            {
                _entries[i].displayEntryData();
            }
        }


    }

    public void SaveJournalToFile()

    {
        //prompt the user to enter the filename
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {

                    sw.WriteLine($"{entry._date} | {entry._question} | {entry._response}");
                }
            }

            Console.WriteLine($"Journal saved to file '{filename}' successfully.");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving data to file: {ex.Message}");
        }


    }
    

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load journal: ");
        string filename = Console.ReadLine();
        List<Entry> loadedEntries = new List<Entry>();
        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split("|");

                    if (parts.Length == 3)
                    {
                        Entry entry = new Entry(parts[1], parts[2], parts[3]);
                        loadedEntries.Add(entry);
                    }
                }
            }

            _entries = loadedEntries;
            Console.WriteLine($"Journal loaded from {filename} successfully!\n");


        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }
        


}