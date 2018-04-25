using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficLibraryConsole.Interface;

namespace AirTrafficLibraryConsole.Classes
{
    public class CalculateVelocity : ICalculators
    {
        public double CalcVelocity(double x1, double x2, double y1, double y2, double time)
        {
            double a = 0, b = 0, speed = 0;

            if (x1 > x2)
            {
                a = x1 - x2;
            }
            else
            {
                a = x2 - x1;
            }

            if (y1 > y2)
            {
                b = y1 - y2;
            }
            else
            {
                b = y2 - y1;
            }

            double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

            if (time < 0)
            {
                time = time * -1;
                speed = c / time;
            }
            else if (time > 0)
            { speed = c / time; }

            return speed;
        }
    }
}
