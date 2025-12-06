using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine("\n1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    quit = true;
                    Console.WriteLine("Goodbye! Keep working on your eternal quest!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShotName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet. Create one first!");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case "1": // Simple Goal
                _goals.Add(new SimpleGoal(name, description, points));
                Console.WriteLine("Simple goal created successfully!");
                break;

            case "2": // Eternal Goal
                _goals.Add(new EternalGoal(name, description, points));
                Console.WriteLine("Eternal goal created successfully!");
                break;

            case "3": // Checklist Goal
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                Console.WriteLine("Checklist goal created successfully!");
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet. Create one first!");
            return;
        }

        Console.WriteLine("\nWhich goal did you accomplish?");
        ListGoalNames();
        Console.Write("Select a goal: ");

        if (int.TryParse(Console.ReadLine(), out int goalIndex) &&
            goalIndex > 0 && goalIndex <= _goals.Count)
        {
            Goal selectedGoal = _goals[goalIndex - 1];

            if (selectedGoal.IsComplete() && selectedGoal is SimpleGoal)
            {
                Console.WriteLine("This goal is already completed!");
                return;
            }

            int pointsEarned = selectedGoal.RecordEvent();
            _score += pointsEarned;

            Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                // Save score first
                writer.WriteLine(_score);

                // Save each goal
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            using (StreamReader reader = new StreamReader(filename))
            {
                // Load score
                _score = int.Parse(reader.ReadLine());

                // Clear existing goals
                _goals.Clear();

                // Load each goal
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Goal goal = CreateGoalFromString(line);
                    if (goal != null)
                    {
                        _goals.Add(goal);
                    }
                }
            }

            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }

    private Goal CreateGoalFromString(string goalString)
    {
        string[] parts = goalString.Split(':');
        if (parts.Length != 2) return null;

        string type = parts[0];
        string[] data = parts[1].Split(',');

        switch (type)
        {
            case "SimpleGoal":
                if (data.Length == 4)
                {
                    return new SimpleGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2]),
                        bool.Parse(data[3])
                    );
                }
                break;

            case "EternalGoal":
                if (data.Length == 3)
                {
                    return new EternalGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2])
                    );
                }
                break;

            case "ChecklistGoal":
                if (data.Length == 6)
                {
                    return new ChecklistGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2]),
                        int.Parse(data[3]),  // bonus
                        int.Parse(data[4]),  // target
                        int.Parse(data[5])   // amountCompleted
                    );
                }
                break;
        }

        return null;
    }
}