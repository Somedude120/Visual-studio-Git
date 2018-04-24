using System;
using System.Collections.Generic;

namespace AirTrafficLibraryConsole.Interface
{
    public interface ITrack
    {
        string _tag { get; set; }
        double _xCoord { get; set; }
        double _yCoord { get; set; }
        double _alt { get; set; }
        DateTime _timestamp { get; set; }
        string _formattedTime { get; set; } //Denne bliver sat i eventhandling og brugt i print
        double _hVelocity { get; set; }
        double _direction { get; set; }
    }
}