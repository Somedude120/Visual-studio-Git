using System.Collections.Generic;

namespace AirTrafficLibraryConsole.Classes
{
    public class TrackObject
    {
        public string _tag { get; set; }
        public string _xCoord { get; set; }
        public string _yCoord { get; set; }
        public string _alt { get; set; }
        public string _datetime { get; set; }
        public string _hVelocity { get; set; }
        public string _direction { get; set; }


        public TrackObject(List<string> trackInfo)
        {
            _tag = trackInfo[0];
            _xCoord = trackInfo[1];
            _yCoord = trackInfo[2];
            _alt = trackInfo[3];
            _datetime = trackInfo[4];
            _direction = "0";
            _hVelocity = "0";

        }
    }
}