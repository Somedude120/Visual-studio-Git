using System.Collections.Generic;
using System.Linq;

namespace AirTrafficLibraryConsole.Classes
{
    public class TrackInfoPosition
    {
        private List<TrackObject> _trackList;
        private List<string> _compareList;

        public void CompareTracks(TrackObject tag)
        {

            if (tag._tag == _compareList.First())
            {
                _compareList.Add(tag._xCoord);
                _compareList.Add(tag._yCoord);
            }
            else
            {
                
            }
        }
    }
}