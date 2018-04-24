using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AirTrafficLibraryConsole.Classes
{
    public class Parse
    {
        public string _info { get; set; }

        public List<string> ParseFlightInfo(string info)
        {
            _info = info;
            List<string> planeList = new List<string>();
            planeList = info.Split(';').ToList();

            return planeList;
        }
        
    }
}