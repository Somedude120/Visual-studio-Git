using System;
using AirTrafficLibraryConsole.Classes;
using AirTrafficLibraryConsole.Interface;
using NUnit.Framework;
using NSubstitute;
using NUnit.Framework.Constraints;

namespace AirTrafficLibrary.Test.Unit
{
    [TestFixture]
    public class SeparationTest
    {
        private SeperationEvent _uut;
        private bool yes, no;
        private ITrack _track1, _track2;
        private CalculateDistance _distance;

        [SetUp]
        public void Setup()
        {
            
            _track1 = Substitute.For<ITrack>();
            _track2 = Substitute.For<ITrack>();
            yes = true;
            no = false;
            _distance = new CalculateDistance();
            _uut = new SeperationEvent(_distance);
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

        [Test]
        public void RaiseAnEventWhenCollisionIsTrue()
        {
            _uut = Substitute.For<SeperationEvent>(_distance);

            bool something = _uut.CollisionDetection(_track1, _track2);

            //Hvis der er kollison så skal dette event ske
            _uut.Received().HandleEvent(something,EventArgs.Empty);
            
            //EventHandling observable = new EventHandling();
            //SeperationEvent observer = new SeperationEvent();
            //observable.SomethingHappened += observer.HandleEvent;

            //observable.DoSomething();
            //Assert.That(observable.DoSomething());
        }

        [Test]
        public void WhenEventRaisedSendLogger()
        {
            
        }

        [Test]
        public void WhenASeparationHappen()
        {

            _uut = new SeperationEvent(_distance);
            
        }
    }
}