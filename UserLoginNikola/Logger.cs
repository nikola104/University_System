using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginNikola
{
    static public class Logger
    {
        static public List<string> currentSessionActivities = new List<string>(); 
    static public IEnumerable<string> LogActivity(string activity)
        {

            string activityLine = DateTime.Now + ";"
              + LoginValidation.currentUserRole + ";"
              + activity;

            currentSessionActivities.Add(activityLine);

            Console.WriteLine();

            return currentSessionActivities;
            
        }

        public static IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            
            List<string> filteredActivities = (from activ in currentSessionActivities where activ.Contains(filter)
                                               select activ).ToList();

            return filteredActivities;

        }




    }
}
