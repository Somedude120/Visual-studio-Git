using System;

namespace AirTrafficLibraryConsole.Classes
{
    public class CalculateCourse
    {
        public double _Angle { get; set; }
        public double _x1 { get; set; }
        public double _x2 { get; set; }
        public double _y1 { get; set; }
        public double _y2 { get; set; }
        public double _dx { get; set; }
        public double _dy { get; set; }

        public CalculateCourse(double x1, double x2, double y1, double y2)
        {
            _x1 = x1;
            _x2 = x2;
            _y1 = y1;
            _y2 = y2;

            _Angle = Calculate(_x1, _x2, _y1, _y2);
        }

        public double Calculate(double x1, double x2, double y1, double y2)
        {
            double Rad2Deg = 180.0 / Math.PI;
            double dx = x2 - x1;
            double dy = y2 - y1;
            double angle = 90 - Math.Atan2(dy, dx) * Rad2Deg;

            if (angle <= 0)
            {
                angle = angle + 360;
            }

            _Angle = angle;
            return _Angle;

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