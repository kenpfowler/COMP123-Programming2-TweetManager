using System;
using System.IO;

namespace Group59
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Display all tweets from tweets.txt
            Console.WriteLine("Here are all the tweets from your saved file: ");
            Console.WriteLine("______________________________________________");
            TweetManager.ShowAll();

            //Display tweets from particular category
            Console.WriteLine("______________________________________________");
            Console.WriteLine("Enter a category to view only those tweets:   ");
            string entry = Console.ReadLine();
            TweetManager.ShowAll(entry);

            //Convert file to JSON format
            Console.WriteLine("Your file has been converted to JSON format. Press anykey to exit.");
            TweetManager.ConvertToJson();
            Console.ReadKey();
        }
    }
}