using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficLibrary
{
    public class PathEvent : EventArgs
    {
        public List<Path> Paths { get; set; }
    }
}
