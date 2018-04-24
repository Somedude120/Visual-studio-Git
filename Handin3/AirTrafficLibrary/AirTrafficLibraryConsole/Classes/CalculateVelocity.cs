using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficLibraryConsole.Interface;

namespace AirTrafficLibraryConsole.Classes
{
    class CalculateVelocity
    {
        public double CalcVelocity(double x1, double x2, double y1, double y2)
        {
            double x3 = 0;
            double y3 = 0;
            double length = 0;

            x3 = x2 - x1;

            y3 = y2 - y1;

            // a^2 + b^2 = c^2 
            length = Math.Pow(x3, 2) + Math.Pow(y3, 2);

            length = Math.Sqrt(length);
            

            // mangler at dividere med tiden.
            return length;
        }
    }
}
