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



            //double x1 = 10, x2 = 90, y1 = 10, y2 = 90;
            //CalculateCourse calculus = new CalculateCourse(x1, x2, y1 , y2);
            ////Console.WriteLine(calculus._x1);
            //Console.WriteLine(calculus._Angle);
            ////Console.WriteLine(calculus.Calculate(x1,x2,y1,y2));


        }

        public static long Velocity(int hour, int minutes, int seconds, int miliseconds)
        {
            int oldhour = hour - hour;
            int oldminute = minutes - minutes;
            int oldseconds = seconds - seconds;
            long result = 0;

            return result;
        }
        
    }
}

