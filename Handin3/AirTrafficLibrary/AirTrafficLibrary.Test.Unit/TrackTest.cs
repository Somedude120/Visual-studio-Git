using System;
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
        private double _xcoord;
        private double _ycoord;
        private double _altitude;
        private DateTime _dateTime;
        private Parse _parse;

        [SetUp]
        public void Setup()
        {
            _List = new List<string>{"Flammen","9000","9000","5000", "20181111111111111" };
            _trackObject = new TrackObject(_List);
            _tag = _List[0];
            _xcoord = double.Parse(_List[1]);
            _ycoord = double.Parse(_List[2]);
            _altitude = double.Parse(_List[3]);
            _dateTime = DateTime.ParseExact(_List[4], "yyyyMMddHHmmssfff",
                System.Globalization.CultureInfo.InvariantCulture);
            _parse = new Parse();

            
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
            Assert.AreEqual(_dateTime, _trackObject._timestamp);
        }
    }
}