using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    public static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
            + LoginValidator.CurrentUsername + ";"
            + LoginValidator.CurrentUserRole + ";"
            + activity;
            currentSessionActivities.Add(activityLine);
        }

        static public void readLogFile()
        {
            StreamReader reader = new StreamReader("test.txt");
            StringBuilder builder = new StringBuilder();
            string line;
            do
            {
                line = reader.ReadLine();
                builder.Append(line);
            }
            while (line != null);
            Console.WriteLine(builder.ToString());
        }

        static public void ReadActivity()
        {
            StringBuilder b = new StringBuilder();
            foreach(string activity in currentSessionActivities){
                b.Append(activity);
            }
        }
    }
}
