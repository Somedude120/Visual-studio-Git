﻿using System.Runtime.InteropServices.ComTypes;
using AirTrafficLibraryConsole.Classes;
using NUnit.Framework;
using NSubstitute;

namespace AirTrafficLibrary.Test.Unit
{
    [TestFixture]
    public class CourseTest
    {
        private CalculateCourse _uut;
        private double _x1, _x2, _y1, _y2;

        [SetUp]
        public void Setup()
        {

            _uut = new CalculateCourse(_x1, _x2, _y1, _y2);
        }

        [Test]
        public void HeadingEast()
        {
            _x1 = 2;
            _x2 = 2;
            _y1 = 0;
            _y2 = 0;
            _uut = new CalculateCourse(_x1, _x2, _y1, _y2);
            Assert.AreEqual(_uut._Angle,90);

        }

        [Test]
        public void HeadingWest()
        {
            _x1 = 2;
            _x2 = 1;
            _y1 = 2;
            _y2 = 2;
            _uut = new CalculateCourse(_x1, _x2, _y1, _y2);
            Assert.AreEqual(_uut._Angle, 270);
        }
        [Test]
        public void HeadingSouth()
        {
            _x1 = 2;
            _x2 = 2;
            _y1 = 2;
            _y2 = 0;
            _uut = new CalculateCourse(_x1, _x2, _y1, _y2);
            Assert.AreEqual(_uut._Angle, 180);
        }
        [Test]
        public void HeadingNorth()
        {
            _x1 = 2;
            _x2 = 2;
            _y1 = 0;
            _y2 = 2;
            _uut = new CalculateCourse(_x1, _x2, _y1, _y2);
            Assert.AreEqual(_uut._Angle, 360);
        }
    }
}