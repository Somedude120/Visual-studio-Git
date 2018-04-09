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
    public class DateTest
    {
        private Parse uut;
        private Track _track;
        private ITransponderReceiver _transponder = TransponderReceiverFactory.CreateTransponderDataReceiver();
        private object _sender;
        List<string> _planelist = new List<string>();
        
        [SetUp]
        public void Setup()
        {
            uut = new Parse();
            _track = new Track(_planelist);
            _transponder = Substitute.For<ITransponderReceiver>();

        }

        [Test]
        public void TrackIsValid_MaxAltitude()
        {
            _transponder.TransponderDataReady += TransponderOnTransponderDataReady;
            _transponder.Received().TransponderDataReady += TransponderOnTransponderDataReady;
        }

        private void TransponderOnTransponderDataReady(object sender, RawTransponderDataEventArgs rawTransponderDataEventArgs)
        {

            Parse obj = new Parse();
            //string Hans;
            //Jeg vil gerne se igennem denne liste TransponderData der ligger i eventargen
            foreach (var HANS in rawTransponderDataEventArgs.TransponderData)
            {
                List<string> ParsedFlight = new List<string>();
                //Ta track obj
                //Parse data igennem så vi får i uformatteretstrings
                Track obj1 = new Track(HANS);
                //Formatere string til 4 forskellige strings
                ParsedFlight = obj.ParseFlightInfo(obj1.UnformattedInfo);
                //Formattere den timestamp fordi den er retarderet
                ParsedFlight[4] = Parse.FormatTimestamp(ParsedFlight[4]);
                //sæt det ind i anden constructor til Track
                //TrackObject obj3 = new TrackObject(ParsedFlight);

                if (FlightMonitor.MonitoredFlightData(ParsedFlight))
                    //Print ud
                    Console.WriteLine($"\nTag: {ParsedFlight[0]}\nXCoord: {ParsedFlight[1]}\nYCoord: {ParsedFlight[2]}\nAltitude: {ParsedFlight[3]}\nTimestamp: {ParsedFlight[4]}");
                //Hans = obj.ParseFlightInfo(HANS);

                _planelist = ParsedFlight;
            }
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

