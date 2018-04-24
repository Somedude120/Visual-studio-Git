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
        public string Path { get; set; }

        public Logger(string path = @"Seperation.Txt") => Path = path;

        public void LogWriter(List<SeperationEvent> seperationEvents)
        {
            using (StreamWriter log = new StreamWriter(Path, true))
            {
                for(int i = 0;  i < seperationEvents.Count; i++)
                {
                    log.WriteLine(i);
                }
            }
        }


        //public void LogWriter(string str)
        //{
        //    _filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        //    try
        //    {
        //        if (str == "")
        //        {
        //            throw new ArgumentException("The provided string is empty");
        //        }

        //        using (StreamWriter w = File.AppendText(_filePath + "\\" + "SeperationLog.txt"))
        //        {
        //            w.Write(str);
        //        }
        //    }
        //    catch (ArgumentException e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw;
        //    }
        //}
    }
}
