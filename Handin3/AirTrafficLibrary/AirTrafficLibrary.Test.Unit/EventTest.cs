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
        private List<string> _splitlist;
        private TrackObject _trackobject;
        private DateTime date;
        private Parse parse;
        private Print _output;

        [SetUp]
        public void Setup()
        {
            
            _receiver = Substitute.For<ITransponderReceiver>();
            _args = new List<string> { "TES123;39045;12932;18000;20151006213456789" };
            _splitlist = new List<string>{ "hans", "15000", "20000", "10000", "10042018" };
            parse = Substitute.For<Parse>();
            
        }

        [Test]
        public void TestingTransponderReceiverEvent()
        {
            //Lav nyt event
            var args = new RawTransponderDataEventArgs(_args);
            //Raise det nye event
            _receiver.TransponderDataReady += Raise.EventWith(args);
            //Checker om det nye event sender det der var i listen op
            Assert.That(args.TransponderData, Is.EqualTo(_args));

        }

        [Test]
        public void TrackContainsTag()
        {
            _args = new List<string> { "TES123;39045;12932;18000;20151006213456789" };
            _splitlist = parse.ParseFlightInfo(_args[0]);
            _trackobject = new TrackObject(_splitlist);

            Assert.That(_trackobject._tag,Is.EqualTo("TES123"));
        }

        [Test]
        public void TrackContainsXCoord()
        {
            _args = new List<string> { "TES123;39045;12932;18000;20151006213456789" };
            _splitlist = parse.ParseFlightInfo(_args[0]);
            _trackobject = new TrackObject(_splitlist);

            Assert.That(_trackobject._xCoord, Is.EqualTo(39045));
        }


        [Test]
        public void TrackIsValid_MinXCoord()
        {
            _args = new List<string> { "TES123;39045;12932;18000;20151006213456789" };
            _splitlist = parse.ParseFlightInfo(_args[0]);
            _trackobject = new TrackObject(_splitlist);

            Assert.That(_trackobject._tag, Is.EqualTo("TES123"));
        }

        [Test]
        public void TrackIsValid_MaxXCoord()
        {
            _args = new List<string> { "TES123;39045;12932;18000;20151006213456789" };
            _splitlist = parse.ParseFlightInfo(_args[0]);
            _trackobject = new TrackObject(_splitlist);

            Assert.That(_trackobject._tag, Is.EqualTo("TES123"));
        }

        [Test]
        public void TrackContainsYCoord()
        {

            _args = new List<string> { "TES123;39045;12932;18000;20151006213456789" };
            _splitlist = parse.ParseFlightInfo(_args[0]);
            _trackobject = new TrackObject(_splitlist);

            Assert.That(_trackobject._yCoord, Is.EqualTo(12932));

        }

        [Test]
        public void TrackWritesLineToConsole()
        {
            _args = new List<string> { "TES123;39045;12932;18000;20151006213456789" };
            _splitlist = parse.ParseFlightInfo(_args[0]);
            _trackobject = new TrackObject(_splitlist);

            _output = new Print(_trackobject);
            

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

