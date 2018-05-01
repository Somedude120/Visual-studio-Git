using System;
using System.Collections.Generic;
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


        
        private EventHandling handler;
        private ITransponderReceiver receiver;
        private List<string> _args;
        private List<string> _splitlist;
        private ITrack _trackobject;
        private DateTime date;
        private Parse parse;
        private Print _output;
        private RawTransponderDataEventArgs args;
        [SetUp]
        public void Setup()
        {
            handler = new EventHandling();
            receiver = Substitute.For<ITransponderReceiver>();
            _args = new List<string> { "TES123;39045;12932;18000;20151006213456789" };
            _splitlist = new List<string> { "hans", "15000", "20000", "10000", "10042018" };
            parse = Substitute.For<Parse>();
            _trackobject = Substitute.For<ITrack>();

        }

        [Test]
        public void GetBlue()
        {
            Assert.AreEqual(2+2,4);
        }
        //[Test]
        //public void HandlingStuff()
        //{
        //    List<string> parsedlist;
        //    parse.ParseFlightInfo("ATR423;39045;12932;14000;20151006213456789").Returns(_splitlist);
        //    _trackobject = new TrackObject(_splitlist);
        //    receiver.TransponderDataReady += Raise.EventWith(args);
            
        //    Assert.AreEqual(39045, _trackobject._xCoord);
        //}

    }
}