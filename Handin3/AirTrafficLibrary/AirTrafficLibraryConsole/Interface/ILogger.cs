using System.Collections.Generic;
using AirTrafficLibraryConsole.Classes;

namespace AirTrafficLibrary.Interface
{
    public interface ILogger
    {
        void LogCollisionToFile(List<TrackObject> collisionPairs);
    }
}