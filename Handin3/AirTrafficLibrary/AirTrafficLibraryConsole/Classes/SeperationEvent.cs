using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficLibraryConsole.Classes;
using AirTrafficLibraryConsole.Interface;

namespace AirTrafficLibraryConsole.Classes
{
    public class SeperationEvent
    {
        public string TagA { get; set; }
        public string TagB { get; set; }
        public DateTime EventTime { get; set; }
        private TrackObject _track;
        private CalculateDistance dist;


        int horizontalConflict = 5000;
        int verticalConflict = 300;

        public SeperationEvent(CalculateDistance distance)
        {
            dist = distance;
        }
        //Will return true if a Track is in another Track's airspace
        public bool CollisionDetection(ITrack track1, ITrack track2)
        {
            double horizontalDistance = dist.CalculateDistance2D(track1._xCoord, track2._xCoord, track1._yCoord, track2._yCoord);
            double verticalDistance = dist.CalculateDistance1D(track1._alt, track2._alt);

            return horizontalDistance < horizontalConflict && verticalDistance < verticalConflict;
        }

        //public bool CollisionDetection(ITrack track1, ITrack track2)
        //{

        //    //Init så der kommer koordinater ind
        //    double xcoord1 = track1._xCoord;
        //    double xcoord2 = track2._xCoord;
        //    double ycoord1 = track1._yCoord;
        //    double ycoord2 = track2._yCoord;

        //    if (xcoord1 == xcoord2 && ycoord1 == ycoord2)
        //    {
                
        //        return true;
        //    }

            
        //    return false;
        //}
        public void HandleEvent(object sender, EventArgs args)
        {
           
            Console.WriteLine("Something happened to your :  " + sender);
        }
    }
}
