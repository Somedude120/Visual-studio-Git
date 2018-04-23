using System;
using System.Collections.Generic;

namespace AirTrafficLibraryConsole.Classes
{
    //test af pipelineview
    //Objektifikation af Track
    public class TrackConversion
    {
        //public string _unformattedInfo;
        public string _tag { get; set; }
        public string _xcoord { get; set; }
        public string _ycoord { get; set; }
        public string _alt { get; set; }
        public string _datetime { get; set; }
        //public string UnformattedInfo { get; set; }
        public string UnformattedInfo { get; set; }

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
            UnformattedInfo = info;
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