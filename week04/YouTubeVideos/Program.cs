using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        // Create videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("C# Programming Tutorial", "CodeMaster", 600);
        video1.AddComment(new Comment("Alice", "Great tutorial! Very helpful for beginners."));
        video1.AddComment(new Comment("Bob", "I learned so much from this video."));
        video1.AddComment(new Comment("Charlie", "Could you make a video on inheritance?"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("ASP.NET Core Web Development", "WebWizard", 1200);
        video2.AddComment(new Comment("Diana", "Perfect timing! I was just starting with ASP.NET."));
        video2.AddComment(new Comment("Emily", "The examples were very practical."));
        video2.AddComment(new Comment("Frank", "Would love to see more about Entity Framework."));
        video2.AddComment(new Comment("Grace", "This helped me complete my project, thank you!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Understanding Abstraction in C#", "OOPExpert", 900);
        video3.AddComment(new Comment("Henry", "Finally understand abstraction! Great explanation."));
        video3.AddComment(new Comment("Anna", "The real-world examples made it so clear."));
        video3.AddComment(new Comment("Jack", "Can you do a follow-up on encapsulation?"));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Building Console Applications", "ConsolePro", 450);
        video4.AddComment(new Comment("Karen", "Short and sweet! Exactly what I needed."));
        video4.AddComment(new Comment("Leo", "The debugging tips were very useful."));
        video4.AddComment(new Comment("Mia", "More console app examples please!"));
        video4.AddComment(new Comment("Nathan", "Perfect for my school assignment."));
        videos.Add(video4);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }

}