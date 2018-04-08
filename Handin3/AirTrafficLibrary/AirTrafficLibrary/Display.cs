using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficLibrary.Interface;

namespace AirTrafficLibrary
{
    class Display : IDisplay
    {
        public Display()
        {
            Pathconfig.pathsUpdated += Print;
        }

        private void Print(object o, PathsUpdatedEventArgs args)
        {
            foreach (var path in args.Paths)
            {
                Console.WriteLine("FlightID: " + path.Id + "\nX-Coordinate: " + path.Xcoord + "\nY-Coordinate: " + path.Ycoord + "\nFlight-Altitude: " + path.Altitude + "\nTimeStamp: " + path.Time.ToString("yyyy-M-d HH:mm:ss:fff"));
            }
        }
    }
}
