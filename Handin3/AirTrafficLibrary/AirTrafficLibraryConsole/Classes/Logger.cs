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
    public class Logger : ILogger
    {
        private string _filePath = string.Empty;

        public void LogWriter(string str)
        {
            _filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            try
            {
                using (StreamWriter w = File.AppendText(_filePath + "\\" + "log.txt"))
                {
                     w.Write(str);
                }
            }
            catch (ArgumentException e)
            {
            }
        }
    }
}
