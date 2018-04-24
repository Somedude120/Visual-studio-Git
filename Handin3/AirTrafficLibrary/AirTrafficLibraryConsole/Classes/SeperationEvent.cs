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

        public bool CollisionDetection(ITrack _track1, ITrack _track2)
        {
            //Input code
            return false;
        }

    }
}
