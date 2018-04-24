﻿using System;

namespace AirTrafficLibraryConsole.Classes
{
    public class Print
    {
        public Print(TrackObject track)
        {
            Console.WriteLine("Tag:\t\t" + track._tag);
            Console.WriteLine("X coordinate:\t" + track._xCoord + " meters");
            Console.WriteLine("Y coordinate:\t" + track._yCoord + " meters");
            Console.WriteLine("Altitude:\t" + track._alt + " meters");
            Console.WriteLine("Timestamp:\t" + track._datetime);
            Console.WriteLine("Direction:\t" + track._direction);
            Console.WriteLine("Velocity:\t" + track._hVelocity);
            Console.WriteLine();
        }
    }
}