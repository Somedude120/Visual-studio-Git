using System;
using System.Collections.Generic;

namespace AirTrafficLibrary
{
    //Objektifikation af Track
    public class Track
    {
        private string _unformattedInfo;
        private string _tag;
        private string _xcoord;
        private string _ycoord;
        private string _alt;
        private string _datetime;

        public string UnformattedInfo
        {
            get { return _unformattedInfo; }

            set { value = _unformattedInfo; }
        }
        

        public Track(List<string> planelist)
        {
            _tag = planelist[0];
            _xcoord = planelist[1];
            _ycoord = planelist[2];
            _alt = planelist[3];
            _datetime = planelist[4];
        }

        public Track(string info)
        {
            //string skal converteres
            _unformattedInfo = info;
        }

        public void Print()
        {
            Console.WriteLine("Tag:\t\t" + _tag);
            Console.WriteLine("X coordinate:\t" + _xcoord + " meters");
            Console.WriteLine("Y coordinate:\t" + _ycoord + " meters");
            Console.WriteLine("Altitide:\t" + _alt + " meters");
            Console.WriteLine("Timestamp:\t" + _datetime);
            Console.WriteLine();
        }

    }
}