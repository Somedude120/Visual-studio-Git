using System.Collections.Generic;
using AirTrafficLibraryConsole.Classes;

namespace AirTrafficLibrary.Interface
{
    public interface ILogger
    {
        void LogWriter(string collisionPairs);
    }
}