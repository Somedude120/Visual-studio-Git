using System.Collections.Generic;
using AirTrafficLibraryConsole.Classes;
using AirTrafficLibraryConsole.Interface;
using NUnit.Framework;

namespace ATMLibrary.IntegrationTest.IT
{
    [TestFixture]
    public class IT2
    {
        private ITrack track;
        private TrackInfoPosition tracker;
        private Parse parse;
        private Print print;
        private FlightMonitor flightmonitor;
        private DataHandler datahandle;
        private SeperationEvent separation;
        private List<string> tracklist;

        [SetUp]
        public void Setup()
        {
            tracklist = new List<string>{"First","Second","Third"};
            track = new TrackObject(tracklist);
            parse = new Parse();
            print = new Print(track);
        }

    }
}