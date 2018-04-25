using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficLibrary.Interface
{
    interface ISeperationEvent
    {
        string Tag { get; set; }
        DateTime TimeOfOccurence { get; set; }
    }
}