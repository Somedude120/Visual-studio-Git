using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace AirTrafficLibrary.Test.Unit
{
    [TestFixture]
    public class EventTest
    {
        private ITransponderReceiver _receiver;
        private List<string> _args;

        [SetUp]
        public void Setup()
        {
            _receiver = Substitute.For<ITransponderReceiver>();
            _args = new List<string>{ "TES123;39045;12932;18000;20151006213456789" };

        }

        [Test]
        public void TestingTransponderReceiverEvent()
        {
            //Lav nyt event
            var args = new RawTransponderDataEventArgs(_args);
            //Raise det nye event
            _receiver.TransponderDataReady += Raise.EventWith(args);
            //Checker om det nye event sender det der var i listen op
            Assert.That(args.TransponderData,Is.EqualTo(_args));

        }

        [Test]
        public void TrackIsValid_MinAltitude()
        {

        }


        [Test]
        public void TrackIsValid_MaxXCoord()
        {

        }

        [Test]
        public void TrackIsValid_MinXCoord()
        {

        }

        [Test]
        public void TrackIsValid_MaxYCoord()
        {

        }

        [Test]
        public void TrackIsValid_MinYCoord()
        {

        }


    }
}

