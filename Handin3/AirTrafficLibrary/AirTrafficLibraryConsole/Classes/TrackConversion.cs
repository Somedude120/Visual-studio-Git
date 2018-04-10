using System;
using System.Collections.Generic;

namespace AirTrafficLibraryConsole.Classes
{
    //Objektifikation af Track
    public class TrackConversion
    {
        public string _unformattedInfo;
        public string _tag;
        public string _xcoord;
        public string _ycoord;
        public string _alt;
        public string _datetime;
        //public string UnformattedInfo { get; set; }
        public string UnformattedInfo
        {
            get { return _unformattedInfo; }

            set { value = _unformattedInfo; }
        }

        public TrackConversion(string tag, string xcoord, string ycoord, string alt, string datetime)
        {
            _tag = tag;
            _xcoord = xcoord;
            _ycoord = ycoord;
            _alt = alt;
            _datetime = datetime;
        }

        public TrackConversion(string info)
        {
            //string skal converteres
            _unformattedInfo = info;
        }

        public void Print()
        {
            Console.WriteLine("Tag:\t\t" + _tag);
            Console.WriteLine("X coordinate:\t" + _xcoord + " meters");
            Console.WriteLine("Y coordinate:\t" + _ycoord + " meters");
            Console.WriteLine("Altitude:\t" + _alt + " meters");
            Console.WriteLine("Timestamp:\t" + _datetime);
            Console.WriteLine();
        }
        public void List(List<string> planelist)
        {
            _tag = planelist[0];
            _xcoord = planelist[1];
            _ycoord = planelist[2];
            _alt = planelist[3];
            _datetime = planelist[4];
        }
    }
}