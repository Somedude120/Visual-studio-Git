using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AirTrafficLibraryConsole.Classes;
using TransponderReceiver;

namespace AirTrafficLibrary
{
    class Program
    {
        
        static void Main()
        {
            
            EventHandling Events = new EventHandling();
            Events.TransponderEventHandler();

            while (true)
            {
                
            }
            
        }

        static public long Velocity(int hour, int minutes, int seconds, int miliseconds)
        {
            int oldhour = hour - hour;
            int oldminute = minutes - minutes;
            int oldseconds = seconds - seconds;
            long result = 0;


            return result;
        }

    }
}
