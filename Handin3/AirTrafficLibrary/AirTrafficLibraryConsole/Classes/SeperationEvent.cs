using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficLibraryConsole.Interface;

namespace AirTrafficLibraryConsole.Classes
{
    public class SeperationEvent
    {
        public string TagA { get; set; }
        public string TagB { get; set; }
        public DateTime EventTime { get; set; }
        private TrackObject _track;

        public bool CollisionDetection(ITrack track1, ITrack track2)
        {

            //Init så der kommer koordinater ind
            double xcoord1 = track1._xCoord;
            double xcoord2 = track2._xCoord;
            double ycoord1 = track1._yCoord;
            double ycoord2 = track2._yCoord;

            if (xcoord1 == xcoord2 && ycoord1 == ycoord2)
            {

                return true;
            }            

            return false;
        }

    }
}
