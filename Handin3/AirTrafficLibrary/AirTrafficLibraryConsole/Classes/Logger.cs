using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficLibrary.Interface;

namespace AirTrafficLibraryConsole.Classes
{
    public class Logger : ILogger
    {
        public string FilePath { get; set; }

        public Logger(string path = @"SeperationLog.txt") => FilePath = path;

        public void LogCollisionToFile(List<TrackObject> collisionPairs)
        {
            using (StreamWriter writer = new StreamWriter(FilePath, true))
            {
                foreach (var pair in collisionPairs)
                {
                    writer.WriteLine(pair.ToString());
                }
            }
        }
    }
}
