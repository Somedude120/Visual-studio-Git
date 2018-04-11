using AirTrafficLibrary.Interface;

namespace AirTrafficLibraryConsole.Classes
{
    public class Plane : IPlaneInfo
    {
        private TrackObject _trackobject;
        public string GetTag(string tag)
        {
            return tag;
        }

        public string GetX(string xcoord)
        {
            return xcoord;
        }

        public string GetY(string ycoord)
        {
            return ycoord;
        }

        public string GetAlt(string altitude)
        {
            return altitude;
        }

        public string GetDate(string date)
        {
            return date;
        }
    }
}