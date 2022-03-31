using System;
using System.Text;
using System.IO;

namespace Logs
{
    public static class Log
    {
        public static void WriteToLogFile(string strLogMessage)
        {
            try
            {
                var strLogFile = "LogFile.txt";
                var log = new StringBuilder();
                bool boolDidFileExistAlready = File.Exists(strLogFile);


                using (StreamWriter writer = new StreamWriter(strLogFile, true))
                {
                    if (!boolDidFileExistAlready)
                    {
                        log.AppendLine("Log file created on " + DateTime.Now.ToString());
                        log.AppendLine("\r\n");
                    }
                    
                    log.AppendLine(DateTime.Now.ToString());
                    log.Append(" | ");
                    log.Append(strLogMessage);
                   
                    writer.WriteLine(log.ToString());
                }
            }
            catch
            {
                Console.WriteLine("Error writing to log file.");
            }
        }
    }
}
