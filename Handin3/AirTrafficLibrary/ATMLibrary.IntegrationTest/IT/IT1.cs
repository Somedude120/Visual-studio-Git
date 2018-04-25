using AirTrafficLibraryConsole.Classes;
using AirTrafficLibraryConsole.Interface;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace ATMLibrary.IntegrationTest.IT
{
    [TestFixture]
    public class IT1
    {
        private ITransponderReceiver _receiver;
        private ITrack track;
        private TrackInfoPosition tracker;

        private FlightMonitor flightmonitor;
        private DataHandler datahandle;
        private SeperationEvent separation;
        private Logger log;

        [SetUp]
        public void Setup()
        {
            _receiver = Substitute.For<ITransponderReceiver>();
        }

        [Test]
        public void StartupTest()
        {
            Assert.AreEqual(2+2,4);
        }

    }
}