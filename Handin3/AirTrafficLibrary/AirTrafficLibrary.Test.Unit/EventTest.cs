using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AirTrafficLibraryConsole.Classes;
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
        public void TrackContainsTag()
        {
            TrackConversion trackC = new TrackConversion("hans", "15000", "20000", "10000", "10042018");
            Assert.That(trackC._tag == "hans");
        }

        [Test]
        public void TrackContainsXCoord()
        {
            TrackConversion trackC = new TrackConversion("hans", "15000", "20000", "10000", "10042018");
            Assert.That(trackC._xcoord == "15000");
        }


        [Test]
        public void TrackIsValid_MinXCoord()
        {

        }

        [Test]
        public void TrackIsValid_MaxXCoord()
        {

        }

        [Test]
        public void TrackContainsYCoord()
        {
            TrackConversion trackC = new TrackConversion("hans", "15000", "20000", "10000", "10042018");
            Assert.That(trackC._ycoord == "20000");

        }

        [Test]
        public void TrackWritesLineToConsole()
        {
            //TrackConversion trackC = new TrackConversion("hans", "15000", "20000", "10000", "10042018");
            //trackC.Print();

            
            System.Diagnostics.Debug.WriteLine("Ta: hans");
        }

        [Test]
        public void TrackIsValid_MinYCoord()
        {

        }

        [Test]
        public void TrackIsValid_MaxYCoord()
        {

        }
    }
}

