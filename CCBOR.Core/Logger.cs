using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCBOR.Core
{
   public class Logger
    {
        public static void AppendToErrors(string message)
        {
            lock ("Errors")
            {
                string fn = AppDomain.CurrentDomain.BaseDirectory + @"Logs\Errors\";
                fn = createFolderPath(fn, DateTime.Now);
                fn += "errors_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".txt";

                //Create the file if it doesn't already exist
                if (!File.Exists(fn))
                {
                    FileStream fs = File.Create(fn);
                    fs.Close();
                }

                //Append to the file
                StreamWriter sw = File.AppendText(fn);
                sw.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "\t" + message);
                sw.Flush();
                sw.Close();
                sw = null;
            }
        }

        public static void AppendToActivity(string message)
        {
            lock ("Activity")
            {
                string fn = AppDomain.CurrentDomain.BaseDirectory + @"Logs\Activity\";
                fn = createFolderPath(fn, DateTime.Now);
                fn += "activity_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".txt";

                //Create the file if it doesn't already exist
                if (!File.Exists(fn))
                {
                    FileStream fs = File.Create(fn);
                    fs.Close();
                }

                //Append to the file
                StreamWriter sw = File.AppendText(fn);
                sw.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "\t" + message);
                sw.Flush();
                sw.Close();
                sw = null;
            }
        }

        public static string StartLoggingSessionActivity(string sessionId)
        {
            lock ("StartingNewLogFile")
            {
                string fn = AppDomain.CurrentDomain.BaseDirectory + @"Logs\Activity\";
                fn = createFolderPath(fn, DateTime.Now);
                fn += sessionId + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".txt";

                //Create the file if it doesn't already exist
                if (!File.Exists(fn))
                {
                    FileStream fs = File.Create(fn);
                    fs.Close();
                }

                return fn;
            }
        }

        public static void AppendToSessionActivity(string fileName, string message)
        {
            lock ("Activity")
            {
                //Create the file if it doesn't already exist
                if (!File.Exists(fileName))
                {
                    FileStream fs = File.Create(fileName);
                    fs.Close();
                }

                //Append to the file
                StreamWriter sw = File.AppendText(fileName);
                sw.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "\t" + message);
                sw.Flush();
                sw.Close();
                sw = null;
            }
        }

        private static string createFolderPath(string baseFolder, DateTime dt)
        {
            string val = "";

            //Create the logs folder if it doesn't exist
            if (!Directory.Exists(baseFolder))
                Directory.CreateDirectory(baseFolder);

            //Create the year folder if it doesn't exist
            val = baseFolder + dt.Year.ToString();
            if (!Directory.Exists(val))
                Directory.CreateDirectory(val);

            //Create the month folder if it doesn't exist
            val = val + @"\" + dt.ToString("MM");
            if (!Directory.Exists(val))
                Directory.CreateDirectory(val);

            //Create the day folder if it doesn't exist
            val = val + @"\" + dt.ToString("dd");
            if (!Directory.Exists(val))
                Directory.CreateDirectory(val);

            return val + @"\";
        }
    }
}
