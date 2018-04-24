using AirTrafficLibraryConsole.Classes;
using AirTrafficLibraryConsole.Interface;
using NUnit.Framework;
using NSubstitute;

namespace AirTrafficLibrary.Test.Unit
{
    [TestFixture]
    public class SeparationTest
    {
        private SeperationEvent _uut;
        private bool yes, no;
        private ITrack _track1, _track2;
        
        [SetUp]
        public void Setup()
        {
            _track1 = Substitute.For<ITrack>();
            _track2 = Substitute.For<ITrack>();
            yes = true;
            no = false;
            _uut = new SeperationEvent();
        }

        [Test]
        public void IsACollisionHappeningTrue()
        {
            _track1._xCoord = 20;
            _track1._yCoord = 20;
            _track2._xCoord = 20;
            _track2._yCoord = 20;
            bool something = _uut.CollisionDetection(_track1, _track2);


            Assert.AreEqual(something, true);

        }
    }
}