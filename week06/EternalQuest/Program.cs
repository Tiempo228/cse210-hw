using System;

class Program
{
    static void Main(string[] args)
    {
        // CREATIVE FEATURES ADDED:
        // 1. Level System - User levels up based on total points
        // 2. Achievement Badges - Earn badges for completing milestones
        // 3. Streak Tracking - Track consecutive days of recording events
        // 4. Goal Categories - Organize goals into different categories

        Console.WriteLine("Welcome to Eternal Quest!");
        Console.WriteLine("A goal tracking system with gamification features!");
        Console.WriteLine("\nCreative Features Included:");
        Console.WriteLine("• Level System with fun titles");
        Console.WriteLine("• Achievement Badges for milestones");
        Console.WriteLine("• Streak Tracking for consecutive days");
        Console.WriteLine("• Goal Categories (Spiritual, Physical, Educational)");
        Console.WriteLine("\nPress Enter to begin...");
        Console.ReadLine();

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}