namespace AirTrafficLibrary
{
    //Objektifikation af Track
    public class Track
    {
        private string _tag;
        private long _xcoord;
        private long _ycoord;
        private long _alt;
        private string _datetime;

        public Track(string tag, long xcoord, long ycoord, long alt, string datetime)
        {
            _tag = tag;
            _xcoord = xcoord;
            _ycoord = ycoord;
            _alt = alt;
            _datetime = datetime;
        }

    }
}