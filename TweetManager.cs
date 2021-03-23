using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Group59
{
    internal class TweetManager
    {
        /* fields */
        private static Tweet[] tweets;
        private static string fileName = "tweets.txt";

        /* constructor */

        static TweetManager()
        {
            //count lines in tweet file
            int lineCount = 0;
            StreamReader reader = new StreamReader(fileName);
            while (reader.ReadLine() != null)
            {
                lineCount++;
            }

            //reset reader
            reader.DiscardBufferedData();
            reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

            //populate tweets array
            tweets = new Tweet[lineCount];
            for (int i = 0; i < lineCount; ++i)
            {
                tweets[i] = Tweet.Process(reader.ReadLine());
            }
            reader.Close();
        }

        /* Methods */

        public static void ShowAll()
        {
            foreach (Tweet t in tweets) Console.WriteLine(t.ToString());
        }

        public static void ShowAll(string categroy)
        {
            foreach (Tweet t in tweets)
            {
                if (t.Category.ToLower() == categroy.ToLower())
                    Console.WriteLine(t.ToString());
            }
        }

        public static void ConvertToJson()
        {
            TextWriter writer = new StreamWriter("tweets.json");
            foreach (Tweet t in tweets)
            {
                string jsonString = JsonSerializer.Serialize(t);
                writer.WriteLine(jsonString);
            }
            writer.Close();
        }
    }
}