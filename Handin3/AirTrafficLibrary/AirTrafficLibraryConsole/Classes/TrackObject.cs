using System;
using System.Collections.Generic;

namespace AirTrafficLibraryConsole.Classes
{
    public class TrackObject
    {
        public string _tag { get; set; }
        public double _xCoord { get; set; }
        public double _yCoord { get; set; }
        public double _alt { get; set; }
        public DateTime _timestamp { get; set; }
        public string _formattedTime { get; set; } //Denne bliver sat i eventhandling og brugt i print
        public double _hVelocity { get; set; }
        public double _direction { get; set; }


        public TrackObject(List<string> trackInfo)
        {

            _tag = trackInfo[0];
            _xCoord = double.Parse(trackInfo[1]);
            _yCoord = double.Parse(trackInfo[2]);
            _alt = double.Parse(trackInfo[3]);
            _timestamp = DateTime.ParseExact(trackInfo[4], "yyyyMMddHHmmssfff",
                System.Globalization.CultureInfo.InvariantCulture);
            _direction = 0;
            _hVelocity = 0;
        }
    }
}