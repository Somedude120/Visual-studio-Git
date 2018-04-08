using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficLibrary.Interface;

namespace AirTrafficLibrary
{
    public class PathCreator : IPathCreator
    {
        public Path CreatePath(string info)
        {
            string[] splitInfo = info.Split(';');

            var path = new Path();

            path.Id = splitInfo[0];
            path.Xcoord = Int32.Parse(splitInfo[1]);
            path.Ycoord = Int32.Parse(splitInfo[2]);
            path.Altitude = UInt32.Parse(splitInfo[3]);
            path.Time = DateTime.ParseExact(splitInfo[4], "yyyyMMddhhmmssff",
                System.Globalization.CultureInfo.InvariantCulture);

            return path;


        }
    }
}
