using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficLibrary.Interface;
using AirTrafficLibraryConsole.Classes;
using AirTrafficLibraryConsole.Interface;

namespace AirTrafficLibraryConsole.Classes
{
    public class SeperationEvent : ISeperationEvent
    {
        public string Tag { get; set; }
        public DateTime TimeOfOccurence { get; set; }
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

        public void HandleEvent(object sender, EventArgs args)
        {
           
           Console.WriteLine("Something happened to your :  " + sender);
        }
    }
}
