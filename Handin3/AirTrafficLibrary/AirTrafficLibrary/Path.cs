using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficLibrary
{
    public class Path
    {
        public string Id { get; set; }
        public int Xcoord { get; set; }
        public int Ycoord { get; set; }
        public uint Altitude { get; set; }
        public DateTime Time { get; set; }

    }
}
