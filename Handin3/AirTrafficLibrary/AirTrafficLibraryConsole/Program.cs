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
            //EventHandling Events = new EventHandling();
            //Events.TransponderEventHandler();

            //while (true)
            //{

            //}

            double x1 = 10, x2 = 10, y1 = 10, y2 = 90;
            Console.WriteLine(CalculateCourse(x1, x2, y1, y2));
        }

        public static long Velocity(int hour, int minutes, int seconds, int miliseconds)
        {
            int oldhour = hour - hour;
            int oldminute = minutes - minutes;
            int oldseconds = seconds - seconds;
            long result = 0;

            return result;
        }

        public static double CalculateCourse(double x1, double x2, double y1, double y2)
        {
            double Rad2Deg = 180.0 / Math.PI;
            double dx = x2 - x1;
            double dy = y2 - y1;
            double angle = 90 - Math.Atan2(dy, dx) * Rad2Deg;

            if (angle <= 0)
            {
                angle = angle + 360;
            }

            return angle;

            //var dif = newY - oldY;
            //Console.WriteLine(dif);
            //var x = Math.Cos(newX) * Math.Sin(dif);
            //Console.WriteLine(x);

            ////oldX = 39 -- newX = 38 -- oldY = -94.5 -- newY = -90.200

            ////Y = cos(39.099912) * sin(38.627089) – sin(39.099912) * cos(38.627089) * cos(4.38101)

            //var y = Math.Cos(oldX) * Math.Sin(newX) - Math.Sin(oldX) * Math.Cos(newX) * Math.Cos(dif);
            //Console.WriteLine(y);

            //var degrees = Math.Atan2(x, y);
            //degrees = degrees * 180 / Math.PI;

            //return degrees;
        }
    }
}

