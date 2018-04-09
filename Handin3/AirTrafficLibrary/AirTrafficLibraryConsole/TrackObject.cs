using System.Collections.Generic;

namespace AirTrafficLibrary
{
    public class TrackObject
    {
        private List<Track> _tracklist;
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
        }

        //public void AddTrack(Track obj)
        //{
        //    _tracklist.Add(obj);
        //}
    }
}