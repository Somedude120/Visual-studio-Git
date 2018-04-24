using System.Collections.Generic;
using AirTrafficLibraryConsole.Classes;
using NSubstitute.Exceptions;
using NUnit.Framework;
using NSubstitute;

namespace AirTrafficLibrary.Test.Unit
{
    [TestFixture]
    public class TrackTest
    {
        private TrackObject _trackObject;
        private List<string> _List;
        private string _tag;
        private string _xcoord;
        private string _ycoord;
        private string _altitude;
        private string _dateTime;

        [SetUp]
        public void Setup()
        {
            _List = new List<string>{"Flammen","9000","9000","5000", "20181111111111111" };
            _trackObject = new TrackObject(_List);
            _tag = _List[0];
            _xcoord = _List[1];
            _ycoord = _List[2];
            _altitude = _List[3];
            _dateTime = _List[4];
            
        }

        [Test]
        public void TrackObject_Receive_Tag()
        {
            Assert.That(_tag,Is.EqualTo(_trackObject._tag));
        }

        [Test]
        public void TrackObject_Receive_XCoords()
        {
            Assert.That(_xcoord, Is.EqualTo(_trackObject._xCoord));
        }
        [Test]
        public void TrackObject_Receive_YCoords()
        {
            Assert.That(_ycoord, Is.EqualTo(_trackObject._yCoord));
        }
        [Test]
        public void TrackObject_Receive_Altitude()
        {
            Assert.That(_altitude, Is.EqualTo(_trackObject._alt));
        }
        [Test]
        public void TrackObject_Receive_DateTime()
        {
            Assert.That(_dateTime, Is.EqualTo(_trackObject._formattedTime));
        }
    }
}