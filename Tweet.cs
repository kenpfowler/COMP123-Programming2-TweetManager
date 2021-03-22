using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Group59
{
    internal class Tweet
    {
        /* Fields */
        static private int recentID = 1;

        /* Properties */
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
        public string Category { get; set; }

        /* Constructor */

        public Tweet(string from, string to, string message, string category)
        {
            From = from;
            To = to;
            Message = message;
            Category = category;
            Id = recentID;
            ++recentID;
        }

        /*Methods*/

        public override string ToString()
        {
            return $"Id: {Id} From: {From} To: {To} Message: {Message} Category: {Category}";
        }

        public static Tweet Process(string line)
        {
            try
            {
                string[] tweet = line.Split('\t');
                return new Tweet(tweet[0], tweet[1], tweet[2], tweet[3]);
            }
            catch (IndexOutOfRangeException)
            {
                return new Tweet("invalid", "invalid", "invalid", "invalid");
            }
        }
    }
}