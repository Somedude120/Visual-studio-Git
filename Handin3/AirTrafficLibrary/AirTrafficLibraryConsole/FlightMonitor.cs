using System;
using System.Collections.Generic;

namespace AirTrafficLibrary
{
    public class FlightMonitor
    {
        public static bool MonitoredFlightData(List<string> planelist)
        {
            return Int32.Parse(planelist[1]) <= 90000
            && Int32.Parse(planelist[1]) >= 10000
            && Int32.Parse(planelist[2]) <= 90000
            && Int32.Parse(planelist[2]) >= 10000
            && Int16.Parse(planelist[3]) >= 500
            && Int16.Parse(planelist[3]) <= 20000;
        }
    }
}