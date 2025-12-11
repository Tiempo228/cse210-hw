using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");
        // Create activities
        List<Activity> activities = new List<Activity>();

        // Create one activity of each type
        DateTime today = DateTime.Today;

        Running runningActivity = new Running(today.AddDays(-3), 30, 3.0);
        Cycling cyclingActivity = new Cycling(today.AddDays(-2), 45, 15.0);
        Swimming swimmingActivity = new Swimming(today.AddDays(-1), 60, 40); // 40 laps

        // Add activities to the list
        activities.Add(runningActivity);
        activities.Add(cyclingActivity);
        activities.Add(swimmingActivity);

        // Display summary for each activity
        Console.WriteLine("Exercise Tracking Summary");
        Console.WriteLine("=========================\n");

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }

        // Optional: Add more activities to demonstrate polymorphism
        Console.WriteLine("Additional Activities");
        Console.WriteLine("=====================\n");

        // Add more activities to the same list
        activities.Add(new Running(today, 45, 4.5));
        activities.Add(new Cycling(today, 60, 18.5));
        activities.Add(new Swimming(today, 30, 20));

        // Display all activities
        for (int i = 0; i < activities.Count; i++)
        {
            Console.WriteLine($"Activity {i + 1}:");
            Console.WriteLine(activities[i].GetSummary());
            Console.WriteLine();
        }
    }
}