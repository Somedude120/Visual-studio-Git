using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AirTrafficLibrary.Interface;


//https://stackoverflow.com/questions/20185015/how-to-write-log-file-in-c


namespace AirTrafficLibraryConsole.Classes
{
    public class Logger
    {
        private string _filePath = string.Empty;
        public Logger(string logMessage)
        {
            LogWriter(logMessage);
        }

        public void LogWriter(string str)
        {
            _filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            try
            {
                if (str == "")
                {
                    throw new ArgumentException("String is empty");
                }

                using (StreamWriter w = File.AppendText(_filePath + "\\" + "SeperationLog.txt"))
                {
                    w.Write(str);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
